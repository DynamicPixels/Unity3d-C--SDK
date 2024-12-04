using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Room.Models;

namespace DynamicPixels.GameService.Services.MultiPlayer.Room
{
    public interface IRoomService
    {
        Task<Room> CreateRoom(CreateRoomParams input);
        Task<Room> CreateAndOpenRoom(CreateRoomParams input);
        Task<IEnumerable<Room>> GetAllRooms(GetAllRoomsParams inputParams);
        Task<IEnumerable<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams);
        Task<Room> GetRoomById(int roomId);
        Task<Room> GetRoomByName(string name);
        Task<Room> Join(int roomId);
        Task<Room> Join(string roomName);
        Task<Room> AutoMatch();
        Task Leave(int roomId);
        Task DeleteRoom(int roomId);
    }
}