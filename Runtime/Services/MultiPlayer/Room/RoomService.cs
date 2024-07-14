using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.MultiPlayer.Room.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using DynamicPixels.GameService.Utils.WebsocketClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Room
{
    public class RoomService : IRoomService
    {
        private readonly ISocketAgent _socketAgent;

        public RoomService(ISocketAgent socketAgent)
        {
            _socketAgent = socketAgent;
        }

        public async Task<Room> CreateRoom(CreateRoomParams input)
        {
            var room = await WebRequest.Post<Room>(UrlMap.CreateRoomUrl, input.ToString());
            room.Config(_socketAgent);
            return room;
        }

        public Task<Room> CreateAndOpenRoom(CreateRoomParams input)
        {
            input.State = RoomStatus.Open;
            return CreateRoom(input);
        }

        public async Task<IEnumerable<Room>> GetAllRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get<RowListResponse<Room>>(UrlMap.GetAllRoomsUrl);
            return response!.List;
        }

        public async Task<IEnumerable<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get<RowListResponse<Room>>(UrlMap.GetAllMatchedRoomsUrl);
            return response!.List;
        }

        public async Task<Room> GetRoomById(int roomId)
        {
            var room = await WebRequest.Get<Room>(UrlMap.GetRoomByIdUrl(roomId));
            room.Config(_socketAgent);
            return room;
        }

        public async Task<Room> GetRoomByName(string name)
        {
            var room = await WebRequest.Get<Room>(UrlMap.GetRoomByNameUrl(name));
            room.Config(_socketAgent);
            return room;
        }

        public async Task<Room> Join(int roomId)
        {
            var room = await WebRequest.Post<Room>(UrlMap.JoinToRoomByIdUrl(roomId));
            room.Config(_socketAgent);
            return room;
        }

        public async Task<Room> Join(string roomName)
        {
            var room = await WebRequest.Post<Room>(UrlMap.JoinToRoomByNameUrl(roomName));
            room.Config(_socketAgent);
            return room;
        }

        public async Task<Room> AutoMatch()
        {
            var room = await WebRequest.Post<Room>(UrlMap.AutoMatchUrl);
            room.Config(_socketAgent);
            return room;
        }

        public Task Leave(int roomId)
        {
            return WebRequest.Delete(UrlMap.LeaveRoomUrl(roomId));
        }

        public Task DeleteRoom(int roomId)
        {
            return WebRequest.Delete(UrlMap.DeleteRoomUrl(roomId));
        }
    }
}