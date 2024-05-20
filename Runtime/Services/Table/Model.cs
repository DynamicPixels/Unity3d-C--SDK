using System.Collections.Generic;
using DynamicPixels.GameService.Models.inputs;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Table
{

    public class FindOptions
    {
        public int Skip { get; set; }
        public int Limit { get; set; }
        [JsonProperty("conditions")]
        public QueryParam Conditions { get; set; }
        [JsonProperty("sorts")]
        public Dictionary<string, Order> Sorts { get; set; } = new Dictionary<string, Order>();

        public List<JoinParams> Joins { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UpdateOptions
    {
        [JsonProperty("conditions")]
        public QueryParam Conditions { get; set; }
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
        public QueryParam Conditions { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class Row
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}