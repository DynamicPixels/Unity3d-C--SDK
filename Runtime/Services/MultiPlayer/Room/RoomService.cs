using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
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
        public async Task<Room> CreateRoom(CreateRoomParams input)
        {
            var room = await WebRequest.Post<Room>(UrlMap.CreateRoomUrl, input.ToString());
            room.Config(_socketAgent);
            return room;
        }

        /// <summary>
        /// Creates and opens a new room with the specified parameters.
        /// The room's status is set to "Open" by default.
        /// </summary>
        /// <param name="input">The parameters required to create and open the room.</param>
        /// <returns>A task representing the asynchronous operation, with the created and opened room as the result.</returns>
        public Task<Room> CreateAndOpenRoom(CreateRoomParams input)
        {
            input.Status = RoomStatus.Open;
            return CreateRoom(input);
        }

        /// <summary>
        /// Retrieves all rooms based on the specified input parameters.
        /// </summary>
        /// <param name="inputParams">The parameters used to filter the rooms.</param>
        /// <returns>A task representing the asynchronous operation, with a collection of rooms as the result.</returns>
        public async Task<IEnumerable<Room>> GetAllRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get<List<Room>>(UrlMap.GetAllRoomsUrl);
            return response!;
        }

        /// <summary>
        /// Retrieves all rooms that match the specified input parameters.
        /// </summary>
        /// <param name="inputParams">The parameters used to match the rooms.</param>
        /// <returns>A task representing the asynchronous operation, with a collection of matched rooms as the result.</returns>
        public async Task<IEnumerable<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get<RowListResponse<Room>>(UrlMap.GetAllMatchedRoomsUrl);
            return response!.List;
        }

        /// <summary>
        /// Retrieves a room by its unique identifier.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room.</param>
        /// <returns>A task representing the asynchronous operation, with the retrieved room as the result.</returns>
        public async Task<Room> GetRoomById(int roomId)
        {
            var room = await WebRequest.Get<Room>(UrlMap.GetRoomByIdUrl(roomId));
            room.Config(_socketAgent);
            return room;
        }

        /// <summary>
        /// Retrieves a room by its name.
        /// </summary>
        /// <param name="name">The name of the room.</param>
        /// <returns>A task representing the asynchronous operation, with the retrieved room as the result.</returns>
        public async Task<Room> GetRoomByName(string name)
        {
            var room = await WebRequest.Get<Room>(UrlMap.GetRoomByNameUrl(name));
            room.Config(_socketAgent);
            return room;
        }

        /// <summary>
        /// Joins a room by its unique identifier.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to join.</param>
        /// <returns>A task representing the asynchronous operation, with the joined room as the result.</returns>
        public async Task<Room> Join(int roomId)
        {
            var room = await WebRequest.Post<Room>(UrlMap.JoinToRoomByIdUrl(roomId));
            room.Config(_socketAgent);
            return room;
        }

        /// <summary>
        /// Joins a room by its name.
        /// </summary>
        /// <param name="roomName">The name of the room to join.</param>
        /// <returns>A task representing the asynchronous operation, with the joined room as the result.</returns>
        public async Task<Room> Join(string roomName)
        {
            var room = await WebRequest.Post<Room>(UrlMap.JoinToRoomByNameUrl(roomName));
            room.Config(_socketAgent);
            return room;
        }

        /// <summary>
        /// Automatically matches the user with a room.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with the matched room as the result.</returns>
        public async Task<Room> AutoMatch()
        {
            var room = await WebRequest.Post<Room>(UrlMap.AutoMatchUrl);
            room.Config(_socketAgent);
            return room;
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
