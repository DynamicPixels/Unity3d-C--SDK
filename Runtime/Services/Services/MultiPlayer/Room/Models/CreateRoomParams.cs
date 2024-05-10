using System.Collections.Generic;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Room.Models
{
    public record CreateRoomParams
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int? MinXp { get; set; }
        public int? MaxXp { get; set; }
        public bool IsPermanent { get; set; }
        public bool? IsTurnBasedGame { get; set; } = false;
        public GameOrderType? GameOrderType { get; set; }
        public string Metadata { get; set; }
        public List<int> Players { get; set; }
    }
}