using GameService.Client.Sdk.Services.Services.MultiPlayer.Match;
using GameService.Client.Sdk.Services.Services.MultiPlayer.Realtime;
using GameService.Client.Sdk.Services.Services.MultiPlayer.Room;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer
{

    public class MultiPlayer
    {
        public MultiPlayer(IRoomService roomService, IMatchService matchService, IRealtimeService realtimeService)
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