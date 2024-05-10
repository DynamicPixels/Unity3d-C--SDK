using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.outputs;
using GameService.Client.Sdk.Repositories.Messaging;
using GameService.Client.Sdk.Utils.HttpClient;
using GameService.Client.Sdk.Utils.WebsocketClient;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Room
{
    public class Room
    {
        private ISocketAgent _socketAgent;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int? MinXp { get; set; }
        public int? MaxXp { get; set; }
        public bool IsPermanent { get; set; }
        public RoomState State { get; set; }
        public bool IsTurnBasedGame { get; set; }
        public GameOrderType? GameOrderType { get; set; }
        public string Metadata { get; set; }
        public int CreatorId { get; set; }
        public List<RoomPlayer> Players { get; set; }


        public event EventHandler<RoomPlayer> OnAfterUserJoinedToRoom;
        public event EventHandler<Room> OnCreateRoom;
        public event EventHandler<int> OnLeaveRoom;
        public event EventHandler<int> OnDisposeRoom;
        public event EventHandler OnDisconnect;
        public event EventHandler<Request> OnMessageReceived;


        public void Config(ISocketAgent socketAgent)
        {
            _socketAgent = socketAgent;
            _socketAgent.OnMessageReceived += OnMessage;
            _socketAgent.OnDisconnect += Disconnect;
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

        private void UserJoinedListenerAction(string message)
        {
            var user = JsonConvert.DeserializeObject<RoomPlayer>(message);

            Players.Add(user);

            OnAfterUserJoinedToRoom?.Invoke(this, user);
        }

        private void UserLeftListenerAction(string message)
        {
            var userId = Convert.ToInt32(message);

            Players.RemoveAll(a => a.UserId == userId);

            OnLeaveRoom?.Invoke(this, userId);
        }

        private void OnMessage(object source, Request packet)
        {
            switch (packet.Method)
            {
                case MessageType.SendToUserMessage:
                case MessageType.BroadcastToRoomMessage:
                    OnMessageReceived?.Invoke(this, packet);
                    break;
                case MessageType.UserJoinedToRoomMessage:
                    UserJoinedListenerAction(packet.Payload);
                    break;
                case MessageType.UserLeftRoomMessage:
                    UserLeftListenerAction(packet.Payload);
                    break;
            }
        }

        private void Disconnect(object sender, EventArgs e)
        {
            if (OnDisconnect != null)
                OnDisconnect(sender, null);
        }
    }

    public struct RoomPlayer
    {
        public int UserId { get; set; }
        public string Metadata { get; set; }
        public List<string> Tags { get; set; }
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

    internal static class MessageType
    {
        public const string BroadcastToRoomMessage = "room:broadcast";
        public const string SendToUserMessage = "room:send-to-user";
        public const string RoomCreatedMessage = "room:created";
        public const string RoomDeletedMessage = "room:deleted";
        public const string UserJoinedToRoomMessage = "room:user-joined";
        public const string UserLeftRoomMessage = "room:leave";
    }
}