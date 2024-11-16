using adapters.services.table.services;
using DynamicPixels.GameService.Services.Achievement;
using DynamicPixels.GameService.Services.Chat;
using DynamicPixels.GameService.Services.Device;
using DynamicPixels.GameService.Services.Friendship;
using DynamicPixels.GameService.Services.Leaderboard;
using DynamicPixels.GameService.Services.MultiPlayer.Match;
using DynamicPixels.GameService.Services.MultiPlayer.Room;
using DynamicPixels.GameService.Services.Party;
using DynamicPixels.GameService.Services.User;
using DynamicPixels.GameService.Utils.WebsocketClient;

namespace DynamicPixels.GameService.Services.Table
{

    public class Services
    {
        public Services(IWebSocketService agent)
        {
            Leaderboard = new LeaderboardService();
            Achievement = new AchievementService();
            Chats = new ChatService(agent);
            Friendship = new FriendshipService();
            Party = new PartyService();
            Users = new UserService();
            Devices = new DeviceService();
            MultiPlayer = new MultiPlayer.MultiPlayer(
                new RoomService(agent),
                new MatchService());
        }

        public ILeaderboard Leaderboard { get; private set; }
        public IAchievement Achievement { get; private set; }
        public IChat Chats { get; private set; }
        public IFriendship Friendship { get; private set; }
        public IParty Party { get; private set; }
        public IUser Users { get; private set; }
        public IDevice Devices { get; private set; }
        public MultiPlayer.MultiPlayer MultiPlayer { get; }
    }
}