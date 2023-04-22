using System;
using Newtonsoft.Json;

namespace models.dto
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Order { get; set; }
        public int Course { get; set; }
        public int TimeFrame { get; set; }
        [JsonProperty("ttl")]
        public int TimeToLive { get; set; }
        public DateTime LastWipe { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Score
    {
        public int Leaderboard { get; set; }
        public int PlayerId { get; set; }
        public bool IsMe { get; set; }
        public bool IsFriend { get; set; }
        public int Value { get; set; }
        public int Tries { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}