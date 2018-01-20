using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.VIEWMODELS.RACE
{
    public class RaceDetails
    {
        public int TotalBets { get; set; }
        public IEnumerable<HorseDetails> Horses { get; set; }
    }
}
