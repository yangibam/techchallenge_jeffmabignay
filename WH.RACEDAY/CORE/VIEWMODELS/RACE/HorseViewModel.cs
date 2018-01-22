using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.VIEWMODELS.RACE
{
    public class HorseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Odds { get; set; }
        public int Bets { get; set; }
        public double Payout { get; set; }
    }
}
