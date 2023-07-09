using System.Collections.Generic;
using models.inputs.QueryHelper;
using Newtonsoft.Json;

namespace models.dto
{
   
    public class FindOptions
    {
        public int Skip { get; set; } = 0;
        public int Limit { get; set; } = 25;
        [JsonProperty("conditions")]
        public QueryParam? Conditions{ get; set; }
        [JsonProperty("sorts")]
        public Dictionary<string, Order>? Sorts { get; set; } = new Dictionary<string, Order>();

        public List<JoinParams>? Joins { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UpdateOptions
    {
        [JsonProperty("conditions")]
        public QueryParam? Conditions{ get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DeleteOptions
    {
        [JsonProperty("conditions")]
        public QueryParam? Conditions{ get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        
    }
    
    public class Row
    {
        public int Id { get; set; }
    }
}