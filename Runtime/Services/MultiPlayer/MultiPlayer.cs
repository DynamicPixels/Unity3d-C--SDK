using DynamicPixels.GameService.Services.MultiPlayer.Match;
using DynamicPixels.GameService.Services.MultiPlayer.Room;

namespace DynamicPixels.GameService.Services.MultiPlayer
{

    public class MultiPlayer
    {
        public MultiPlayer(IRoomService roomService, IMatchService matchService)
        {
            RoomService = roomService;
            MatchService = matchService;
        }

        public IRoomService RoomService { get; }
        public IMatchService MatchService { get; }
    }
}