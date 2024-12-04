using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Friendship.Models
{
    public class GetMyFriendsParams
    {
        public int Skip { get; set; }
        public int Limit { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class GetMyFriendshipRequestsParams
    {
        public int Skip { get; set; }
        public int Limit { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RequestFriendshipParams
    {
        [JsonProperty("target_user_id")]
        public int UserId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class AcceptRequestParams
    {

        public int RequestId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RejectRequestParams
    {
        public int RequestId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RejectAllRequestsParams
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DeleteFriendParams
    {
        [JsonProperty("target_user_id")]
        public int UserId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}