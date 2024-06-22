using DynamicPixels.GameService.Services.MultiPlayer.Match;
using DynamicPixels.GameService.Services.MultiPlayer.Realtime;
using DynamicPixels.GameService.Services.MultiPlayer.Room;

namespace DynamicPixels.GameService.Services.MultiPlayer
{

    public class MultiPlayer
    {
        public MultiPlayer(IRoomService roomService, IMatchService matchService, IRealtimeService realtimeService)
        {
            RoomService = roomService;
            MatchService = matchService;
            //RealtimeService = realtimeService;
        }

        public IRoomService RoomService { get; }
        public IMatchService MatchService { get; }
        //public IRealtimeService RealtimeService { get; }
    }
}