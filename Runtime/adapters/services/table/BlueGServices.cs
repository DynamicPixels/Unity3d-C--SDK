using adapters.services.table.services;
using ports.services;
using ports.utils;

namespace adapters.services.table
{
    public class DynamicPixelsServices
    {
        public DynamicPixelsServices(ISocketAgent agent)
        {
            Leaderboard = new LeaderboardService();
            Achievement = new AchievementService();
            Chats = new ChatService(agent);
            Friendship = new FriendshipService();
            Party = new PartyService();
            Users = new UserService();
            Devices = new DeviceService();
        }
        public ILeaderboard Leaderboard { get; private set; }
        public IAchievement Achievement { get; private set; }
        public IChat Chats { get; private set; } 
        public IFriendship Friendship { get; private set; }
        public IParty Party { get; private set; }
        public IUser Users { get; private set; } 
        public IDevice Devices { get; private set; } 
    }
}