using System.Collections.Generic;
using DynamicPixels.GameService.Services.User.Models;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match.Models
{
    public class MatchSummary
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int RoomName { get; set; }
        public MatchStatus Status { get; set; }
        public IEnumerable<UserSummary> Players { get; set; }
    }
}