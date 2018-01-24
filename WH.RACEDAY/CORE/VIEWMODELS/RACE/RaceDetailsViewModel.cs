using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.VIEWMODELS.RACE
{
    public class RaceDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Status { get; set; }
        public int TotalBets { get; set; }
        public List<HorseViewModel> Horses { get; set; }
    }
}
