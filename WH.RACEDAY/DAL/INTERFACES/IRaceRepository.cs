using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.RACE;

namespace WH.RACEDAY.DAL.INTERFACES
{
    public interface IRaceRepository
    {
        IEnumerable<Race> GetRace();
        IEnumerable<Bet> GetBet();        
    }
}
