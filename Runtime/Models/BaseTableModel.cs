using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models
{
    public class BaseTableModel
    {
        [JsonIgnore]
        public int id;
        public int? owner;
        
        [JsonProperty("id")]
        private int idOnSerializeSetter
        {
            set { id = value; }
        }
    }
}