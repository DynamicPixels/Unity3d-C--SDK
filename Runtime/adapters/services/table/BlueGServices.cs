using adapters.services.table.services;
using ports.services;

namespace adapters.services.table
{
    public class BlueGServices
    {
         
        public ILeaderboard Leaderboard { get; set; } = new LeaderboardService();
        public IAchievement Achievement { get; set; } = new AchievementService();
        public IChat Chats { get; set; } = new ChatService();
        public IFriendship Friendship { get; set; } = new FriendshipService();
        public IParty Party { get; set; } = new PartyService();
        public IUser Users { get; set; } = new UserService();
        public IDevice Devices { get; set; } = new DeviceService();
    }
}