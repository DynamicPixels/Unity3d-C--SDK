using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Match;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Realtime;
using GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame
{

    public class MultiPlayerGame
    {
        public MultiPlayerGame(IRoomService roomService, IMatchService matchService, IRealtimeService realtimeService)
        {
            RoomService = roomService;
            MatchService = matchService;
            RealtimeService = realtimeService;
        }

        public IRoomService RoomService { get; }
        public IMatchService MatchService { get; }
        public IRealtimeService RealtimeService { get; }
    }
}