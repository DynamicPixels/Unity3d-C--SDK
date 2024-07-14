using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;
using DynamicPixels.GameService.Utils.HttpClient;

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

        public Task<Match> Save(string matchMetadata)
        {
            return WebRequest.Put<Match>(UrlMap.SaveUrl(Id), $"{{ metadata: {matchMetadata} }}");
        }

        public  Task SaveState(string key, string value)
        {
            return WebRequest.Put(UrlMap.SaveState(Id, key), $"{{ value: {value} }}");
        }

        public async Task<string> LoadState(string key)
        {
            var result = await WebRequest.Get<MatchState>(UrlMap.LoadState(Id, key));
            return result.StateData;
        }

        public Task<MatchPlayer> SavePlayerData(string metadata)
        {
            return WebRequest.Put<MatchPlayer>(UrlMap.SavePlayerMetaDataUrl(Id), $"{{ metadata: {metadata} }}");

        }

        public Task<Match> Start()
        {
            return UpdateStatus(MatchStatus.Started);
        }

        public Task<Match> Pause(string metadata)
        {
            return UpdateStatus(MatchStatus.Paused);
        }

        public Task<Match> Resume()
        {
            return UpdateStatus(MatchStatus.Resumed);
        }

        public Task Finish(string metadata)
        {
            return WebRequest.Put(UrlMap.FinishMatchUrl(Id), $"{{ metadata: {metadata} }}");
        }

        public Task LeaveAndAbort()
        {
            return WebRequest.Delete(UrlMap.LeaveAndAbortUrl(Id));
        }

        private Task<Match> UpdateStatus(MatchStatus status)
        {
            return WebRequest.Put<Match>(UrlMap.UpdateMatchStatusUrl(Id), $"{{ status: {status} }}");
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