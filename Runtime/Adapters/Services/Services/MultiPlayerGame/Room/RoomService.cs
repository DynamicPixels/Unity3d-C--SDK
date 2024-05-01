using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room.Models;
using GameService.Client.Sdk.Adapters.Utils.HttpClient;
using GameService.Client.Sdk.Adapters.Utils.WebsocketClient;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.outputs;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room
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
            var response = await WebRequest.Post(UrlMap.CreateRoomUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<IEnumerable<Room>> GetAllRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get(UrlMap.GetAllRoomsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Room>>(body)!.List;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<IEnumerable<Room>> GetAllMatchedRooms(GetAllRoomsParams inputParams)
        {
            var response = await WebRequest.Get(UrlMap.GetAllMatchedRoomsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Room>>(body)!.List;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Room> GetRoomById(int roomId)
        {
            var response = await WebRequest.Get(UrlMap.GetRoomByIdUrl(roomId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Room> GetRoomByName(string name)
        {
            var response = await WebRequest.Get(UrlMap.GetRoomByNameUrl(name));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Room> Join(int roomId)
        {
            var response = await WebRequest.Post(UrlMap.JoinRoomByIdUrl(roomId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Room> Join(string roomName)
        {
            var response = await WebRequest.Post(UrlMap.JoinRoomByNameUrl(roomName));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Room> AutoMatch()
        {
            var response = await WebRequest.Post(UrlMap.AutoMatchUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var room = JsonConvert.DeserializeObject<RowResponse<Room>>(body)!.Row;
                room.Config(_socketAgent);
                return room;
            }

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task Leave(int roomId)
        {
            var response = await WebRequest.Delete(UrlMap.LeaveRoomUrl(roomId));
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

        public async Task DeleteRoom(int roomId)
        {
            var response = await WebRequest.Delete(UrlMap.DeleteRoomUrl(roomId));
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
}