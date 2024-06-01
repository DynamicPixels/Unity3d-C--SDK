using DynamicPixels.GameService.Models;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Room.Models
{
    public class GetAllRoomsParams : BaseGetAllParams
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}