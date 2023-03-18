using System;

namespace models.dto
{
    public class Friendship
    {
        public int PairOne { get; set; }
        public int PairTwo { get; set; }
        public int Status { get; set; }
        public DateTime? AcceptedAt { get; set; }
    }
}