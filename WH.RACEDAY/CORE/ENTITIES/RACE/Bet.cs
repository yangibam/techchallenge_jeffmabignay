﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.ENTITIES.RACE
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public int Stake { get; set; }
    }
}
