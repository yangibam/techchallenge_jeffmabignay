using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.RACE;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.RACE;
using WH.RACEDAY.DAL.INTERFACES;

namespace WH.RACEDAY.RULE.QUERYHANDLER.RACE
{
    public class GetRaceListQueryHandler : IQueryHandler<GetRaceListQuery, List<Race>>
    {
        private readonly IRaceRepository raceRepository;

        public GetRaceListQueryHandler(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public List<Race> Handle(GetRaceListQuery query)
        {
            var races = this.raceRepository.GetRace();

            return races == null ? new List<Race>() : races.ToList();
        }
    }
}
