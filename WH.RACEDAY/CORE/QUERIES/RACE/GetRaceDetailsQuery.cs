using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.VIEWMODELS.RACE;

namespace WH.RACEDAY.CORE.QUERIES.RACE
{
    public class GetRaceDetailsQuery:IQuery<RaceDetailsViewModel>
    {
        public int ID { get; set; }
    }
}
