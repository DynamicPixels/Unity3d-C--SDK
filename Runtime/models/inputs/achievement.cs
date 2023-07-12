namespace models.inputs
{
    public class GetAchievementParams
    {
        
    }

    public class UnlockAchievementParams
    {
        public int AchievementId { get; set; }
        public int StepId { get; set; }
    }
}