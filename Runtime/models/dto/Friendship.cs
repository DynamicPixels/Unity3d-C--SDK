using System;
using Newtonsoft.Json;

namespace models.dto
{
    public class Friendship
    {
        public int PairOne { get; set; }
        public int PairTwo { get; set; }
        public int Status { get; set; }
        public DateTime? AcceptedAt { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}