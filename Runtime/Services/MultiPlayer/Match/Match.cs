using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
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


        public async Task<Match> Save(string metadata)
        {
            var response = await WebRequest.Put(UrlMap.SaveUrl(Id), $"{{ metadata: {metadata} }}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Match> SavePlayerMetaData(int playerId, string metadata)
        {
            var response = await WebRequest.Put(UrlMap.SavePlayerMetaDataUrl(Id), $"{{ metadata: {metadata} }}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
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

        public async Task<Match> Finish(string metadata)
        {
            var response = await WebRequest.Put(UrlMap.FinishMatchUrl(Id), $"{{ metadata: {metadata} }}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task LeaveAndAbort()
        {
            var response = await WebRequest.Delete(UrlMap.LeaveAndAbortUrl(Id));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        private async Task<Match> UpdateStatus(MatchStatus status)
        {
            var response = await WebRequest.Put(UrlMap.UpdateMatchStatusUrl(Id), $"{{ status: {status} }}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
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