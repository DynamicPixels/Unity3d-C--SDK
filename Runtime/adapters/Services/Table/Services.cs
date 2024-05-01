using GameService.Client.Sdk.Adapters.Services.Services.Achievement;
using GameService.Client.Sdk.Adapters.Services.Services.Chat;
using GameService.Client.Sdk.Adapters.Services.Services.Device;
using GameService.Client.Sdk.Adapters.Services.Services.Friendship;
using GameService.Client.Sdk.Adapters.Services.Services.Leaderboard;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Match;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Realtime;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room;
using GameService.Client.Sdk.Adapters.Services.Services.Party;
using GameService.Client.Sdk.Adapters.Services.Services.User;
using GameService.Client.Sdk.Adapters.Utils.WebsocketClient;

namespace GameService.Client.Sdk.Adapters.Services.Table
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
            MultiPlayerGame = new MultiPlayerGame(
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
        public MultiPlayerGame MultiPlayerGame { get; }
    }
}