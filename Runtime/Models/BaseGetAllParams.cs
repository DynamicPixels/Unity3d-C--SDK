namespace GameService.Client.Sdk.Models
{
    public abstract class BaseGetAllParams
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}