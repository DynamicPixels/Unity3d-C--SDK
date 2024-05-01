using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room.Models;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room
{
    public interface IRoomService
    {
        /// <summary>
        /// Create a room in initial state
        /// </summary>
        /// <param name="input">The room's specifications</param>
        /// <returns>The complete room object with players</returns>
        Task<Room> CreateRoom(CreateRoomParams input);

        /// <summary>
        /// Get all existing rooms
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetAllRooms(GetAllRoomsParams inputParams);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<Room> GetRoomById(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Room> GetRoomByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<Room> Join(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        Task<Room> Join(string roomName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Room> AutoMatch();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task Leave(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task DeleteRoom(int roomId);
    }
}