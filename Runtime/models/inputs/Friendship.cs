namespace models.inputs
{
    public class GetMyFriendsParams
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class GetMyFriendshipRequestsParams
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class RequestFriendshipParams
    {
        public int UserId { get; set; }
    }

    public class AcceptRequestParams
    {
        public int RequestId { get; set; }
    }

    public class RejectRequestParams
    {
        public int RequestId { get; set; }
    }

    public class RejectAllRequestsParams
    {
        
    }

    public class DeleteFriendParams
    {
        public int UserId { get; set; }
    }
}