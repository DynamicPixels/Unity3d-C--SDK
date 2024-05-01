using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Messaging;
using GameService.Client.Sdk.Adapters.Utils.HttpClient;
using GameService.Client.Sdk.Adapters.Utils.WebsocketClient;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.outputs;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room
{
    public class Room
    {
        private ISocketAgent _socketAgent;

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsPrivate { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int? MinXp { get; set; }
        public int? MaxXp { get; set; }
        public bool IsPermanent { get; set; }
        public RoomState State { get; set; }
        public bool IsTurnBasedGame { get; set; }
        public GameOrderType? GameOrderType { get; set; }
        public string? Metadata { get; set; }
        public int CreatorId { get; set; }
        public List<RoomPlayer>? Players { get; set; }


        public void Config(ISocketAgent socketAgent)
        {
            _socketAgent = socketAgent;
        }

        public Task SendToUser(int receiverId, string message)
        {
            var packet = new Request()
            {
                Method = "room:send-to-user",
                UserId = receiverId,
                Payload = message
            };

            return _socketAgent.Send(packet);
        }

        public Task Broadcast(string message)
        {
            var packet = new Request()
            {
                Method = "room:broadcast",
                Payload = message
            };

            return _socketAgent.Send(packet);
        }

        // listener

        public async Task Leave()
        {
            var response = await WebRequest.Delete(UrlMap.LeaveRoomUrl(Id));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }
    }

    public struct RoomPlayer
    {
        public int UserId { get; set; }
        public string? Metadata { get; set; }
        public List<string>? Tags { get; set; }
    }

    public enum RoomState
    {
        Initial = 0,
        Open = 1,
        Lock = 2,
        Closed = 3
    }

    public enum GameOrderType
    {
        Random = 1,
        RoundRobin = 2,
        UserDefined = 3
    }
}