using Newtonsoft.Json;

namespace GameService.Client.Sdk.Models.inputs
{
    public class GetAchievementParams
    {
        public int Skip = 0;
        public int Limit = 25;
        public bool JustUnlocked = true;
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UnlockAchievementParams
    {
        [JsonProperty("achievement_id")]
        public int AchievementId { get; set; }
        [JsonProperty("step_id")]
        public int StepId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}