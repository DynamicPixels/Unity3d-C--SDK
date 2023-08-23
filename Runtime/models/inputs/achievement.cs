using Newtonsoft.Json;
namespace models.inputs
{
    public class GetAchievementParams
    {
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