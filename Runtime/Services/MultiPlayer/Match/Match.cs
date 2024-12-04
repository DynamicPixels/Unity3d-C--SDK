using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    public class Match
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public MatchStatus Status { get; set; }
        public string Metadata { get; set; }
        public IEnumerable<MatchPlayer> Players { get; set; }
        public Room.Room Room { get; set; }

        /// <summary>
        /// Saves the match metadata to the server.
        /// </summary>
        /// <param name="matchMetadata">The metadata to be saved for the match.</param>
        /// <returns>A task representing the asynchronous operation, with the updated match as the result.</returns>
        public Task<Match> Save(string matchMetadata)
        {
            var data = new { Metadata = matchMetadata };
            return WebRequest.Put<Match>(UrlMap.SaveUrl(Id), JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Saves a specific state associated with the match to the server.
        /// </summary>
        /// <param name="key">The key identifying the state.</param>
        /// <param name="value">The value of the state to be saved.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task SaveState(string key, string value)
        {
            var data = new { StateData = value };
            return WebRequest.Put(UrlMap.SaveState(Id, key), JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Loads a specific state associated with the match from the server.
        /// </summary>
        /// <param name="key">The key identifying the state to be loaded.</param>
        /// <returns>A task representing the asynchronous operation, with the state data as the result.</returns>
        public async Task<string> LoadState(string key)
        {
            var result = await WebRequest.Get<MatchState>(UrlMap.LoadState(Id, key));
            return result.StateData;
        }

        /// <summary>
        /// Saves player-specific metadata for the match.
        /// </summary>
        /// <param name="metadata">The metadata to be saved for the player.</param>
        /// <returns>A task representing the asynchronous operation, with the updated player data as the result.</returns>
        public Task<MatchPlayer> SavePlayerData(string metadata)
        {
            var data = new { Metadata = metadata };
            return WebRequest.Put<MatchPlayer>(UrlMap.SavePlayerMetaDataUrl(Id), JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Starts the match by updating its status to "Started".
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the updated match as the result.</returns>
        public Task<Match> Start()
        {
            return UpdateStatus(MatchStatus.Started);
        }

        /// <summary>
        /// Pauses the match by updating its status to "Paused".
        /// </summary>
        /// <param name="metadata">Additional metadata related to pausing the match.</param>
        /// <returns>A task representing the asynchronous operation, with the updated match as the result.</returns>
        public Task<Match> Pause(string metadata)
        {
            Save(metadata);
            return UpdateStatus(MatchStatus.Paused);
        }

        /// <summary>
        /// Resumes the match by updating its status to "Resumed".
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the updated match as the result.</returns>
        public Task<Match> Resume()
        {
            return UpdateStatus(MatchStatus.Resumed);
        }

        /// <summary>
        /// Finishes the match by sending a request to the server to update the match status to "Finished".
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task Finish()
        {
            return WebRequest.Patch(UrlMap.FinishMatchUrl(Id));
        }

        /// <summary>
        /// Leaves the match and aborts it by sending a request to the server to update the match status to "Aborted".
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task LeaveAndAbort()
        {
            return WebRequest.Delete(UrlMap.LeaveAndAbortUrl(Id));
        }

        /// <summary>
        /// Updates the status of the match to the specified status.
        /// </summary>
        /// <param name="status">The new status to set for the match.</param>
        /// <returns>A task representing the asynchronous operation, with the updated match as the result.</returns>
        private Task<Match> UpdateStatus(MatchStatus status)
        {
            var data = new { Status = status };
            return WebRequest.Put<Match>(UrlMap.UpdateMatchStatusUrl(Id), JsonConvert.SerializeObject(data));
        }
    }
    
    public struct MatchPlayer
    {
        public int UserId { get; set; }
        
        public bool? IsTurn { get; set; }
        
        public PlayerState State { get; set; }
        
        public List<string> Tags { get; set; }
        
        public string Metadata { get; set; }
    }
    
    public enum PlayerState
    {
        Init = 1,
        
        Timeout = 2,
        
        LostConnection = 3,
        
        GameOver = 4,
        
        Win = 5,
    }
    
    public enum MatchStatus
    {
        Init = 0,
        
        Started = 1,
        
        Paused = 2,
        
        Resumed = 3,
        
        Finished = 4,
        
        Aborted = 5
    }
}
