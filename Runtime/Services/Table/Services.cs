using GameService.Client.Sdk.Services.Services.Achievement;
using GameService.Client.Sdk.Services.Services.Chat;
using GameService.Client.Sdk.Services.Services.Device;
using GameService.Client.Sdk.Services.Services.Friendship;
using GameService.Client.Sdk.Services.Services.Leaderboard;
using GameService.Client.Sdk.Services.Services.MultiPlayer;
using GameService.Client.Sdk.Services.Services.MultiPlayer.Match;
using GameService.Client.Sdk.Services.Services.MultiPlayer.Realtime;
using GameService.Client.Sdk.Services.Services.MultiPlayer.Room;
using GameService.Client.Sdk.Services.Services.Party;
using GameService.Client.Sdk.Services.Services.User;
using GameService.Client.Sdk.Utils.WebsocketClient;

namespace GameService.Client.Sdk.Services.Table
{

    public class Services
    {
        public Services(ISocketAgent agent)
        {
            Leaderboard = new LeaderboardService();
            Achievement = new AchievementService();
            //Chats = new ChatService();
            Friendship = new FriendshipService();
            Party = new PartyService();
            Users = new UserService();
            Devices = new DeviceService();
            MultiPlayer = new MultiPlayer(
                new RoomService(agent),
                new MatchService(),
                new RealtimeService(agent));
        }

        public ILeaderboard Leaderboard { get; private set; }
        public IAchievement Achievement { get; private set; }
        public IChat Chats { get; private set; }
        public IFriendship Friendship { get; private set; }
        public IParty Party { get; private set; }
        public IUser Users { get; private set; }
        public IDevice Devices { get; private set; }
        public MultiPlayer MultiPlayer { get; }
    }
}