using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Leaderboard.Models;
using DynamicPixels.GameService.Services.MultiPlayer.Room.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using DynamicPixels.GameService.Utils.WebsocketClient;

namespace DynamicPixels.GameService.Services.MultiPlayer.Room
{
    public class RoomService : IRoomService
    {
        private readonly IWebSocketService _socketAgent;

        /// <summary>
        /// Initializes a new instance of the RoomService class with the specified socket agent.
        /// </summary>
        /// <param name="socketAgent">The socket agent used for real-time communication with the server.</param>
        public RoomService(IWebSocketService socketAgent)
        {
            _socketAgent = socketAgent;
        }

        /// <summary>
        /// Creates a new room with the specified parameters.
        /// Configures the room with the socket agent after creation.
        /// </summary>
        /// <param name="input">The parameters required to create the room.</param>
        /// <returns>A task representing the asynchronous operation, with the created room as the result.</returns>
        public async Task<RowResponse<Room>> CreateRoom(CreateRoomParams input, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Post<Room>(UrlMap.CreateRoomUrl, input.ToString());
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Creates and opens a new room with the specified parameters.
        /// The room's status is set to "Open" by default.
        /// </summary>
        /// <param name="input">The parameters required to create and open the room.</param>
        /// <returns>A task representing the asynchronous operation, with the created and opened room as the result.</returns>
        public Task<RowResponse<Room>> CreateAndOpenRoom(CreateRoomParams input, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            input.Status = RoomStatus.Open;
            return CreateRoom(input);
        }

        /// <summary>
        /// Retrieves all rooms based on the specified input parameters.
        /// </summary>
        /// <param name="inputParams">The parameters used to filter the rooms.</param>
        /// <returns>A task representing the asynchronous operation, with a collection of rooms as the result.</returns>
        public async Task<RowListResponse<Room>> GetAllRooms(GetAllRoomsParams inputParams, Action<List<Room>> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var response = await WebRequest.Get<List<Room>>(UrlMap.GetAllRoomsUrl);
            if (response.Successful)
            {
                successfulCallback?.Invoke(response.Result);
            }
            else
            {
                failedCallback?.Invoke(response.ErrorCode, response.ErrorMessage);
            }
            return new RowListResponse<Room>()
            {
                List = response.Result,
                ErrorCode = response.ErrorCode,
                ErrorMessage = response.ErrorMessage,
                Successful = response.Successful,

            };
        }

        /// <summary>
        /// Retrieves all rooms that match the specified input parameters.
        /// </summary>
        /// <param name="inputParams">The parameters used to match the rooms.</param>
        /// <returns>A task representing the asynchronous operation, with a collection of matched rooms as the result.</returns>
        public async Task<RowListResponse<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams, Action<List<Room>> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null )
        {
            var response = await WebRequest.Get<RowListResponse<Room>>(UrlMap.GetAllMatchedRoomsUrl);
            response.Result.Successful = response.Successful;
            response.Result.ErrorCode = response.ErrorCode;
            response.Result.ErrorMessage = response.ErrorMessage;
            if (response.Successful)
            {
                successfulCallback?.Invoke(response.Result.List);
            }
            else
            {
                failedCallback?.Invoke(response.ErrorCode, response.ErrorMessage);
            }
            return response.Result;
        }

        /// <summary>
        /// Retrieves a room by its unique identifier.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room.</param>
        /// <returns>A task representing the asynchronous operation, with the retrieved room as the result.</returns>
        public async Task<RowResponse<Room>> GetRoomById(int roomId, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Get<Room>(UrlMap.GetRoomByIdUrl(roomId));
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Retrieves a room by its name.
        /// </summary>
        /// <param name="name">The name of the room.</param>
        /// <returns>A task representing the asynchronous operation, with the retrieved room as the result.</returns>
        public async Task<RowResponse<Room>> GetRoomByName(string name, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Get<Room>(UrlMap.GetRoomByNameUrl(name));
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Joins a room by its unique identifier.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to join.</param>
        /// <returns>A task representing the asynchronous operation, with the joined room as the result.</returns>
        public async Task<RowResponse<Room>> Join(int roomId, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Post<Room>(UrlMap.JoinToRoomByIdUrl(roomId));
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Joins a room by its name.
        /// </summary>
        /// <param name="roomName">The name of the room to join.</param>
        /// <returns>A task representing the asynchronous operation, with the joined room as the result.</returns>
        public async Task<RowResponse<Room>> Join(string roomName, Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Post<Room>(UrlMap.JoinToRoomByNameUrl(roomName));
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Automatically matches the user with a room.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the matched room as the result.</returns>
        public async Task<RowResponse<Room>> AutoMatch(Action<Room> successfulCallback = null,
            Action<ErrorCode, string> failedCallback = null)
        {
            var result = await WebRequest.Post<Room>(UrlMap.AutoMatchUrl);
            result.Result.Config(_socketAgent);
            if (result.Successful)
            {
                successfulCallback?.Invoke(result.Result);
            }
            else
            {
                failedCallback?.Invoke(result.ErrorCode, result.ErrorMessage);
            }

            return new RowResponse<Room>()
            {
                Row = result.Result,
                Successful = result.Successful,
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage
            };
        }

        /// <summary>
        /// Leaves the room with the specified unique identifier.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to leave.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task Leave(int roomId)
        {
            return WebRequest.Delete(UrlMap.LeaveRoomUrl(roomId));
        }

        /// <summary>
        /// Deletes the room with the specified unique identifier.
        /// Sends a DELETE request to the server to delete the room.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteRoom(int roomId)
        {
            return WebRequest.Delete(UrlMap.DeleteRoomUrl(roomId));
        }
    }
}
