using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.RACE;

namespace WH.RACEDAY.CORE.VIEWMODELS.RACE
{
    public class HorseDetails:Horse
    {
        public int Bets { get; set; }
        public double Payout { get; set; }
    }
}
