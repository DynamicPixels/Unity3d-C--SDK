using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match.Models
{
    public class MakeMatchParams
    {
        public int RoomId { get; set; }
        public bool LockRoom { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
