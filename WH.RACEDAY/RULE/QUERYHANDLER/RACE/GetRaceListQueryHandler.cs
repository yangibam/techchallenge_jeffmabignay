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
    public class GetRaceListQueryHandler : IQueryHandler<GetRaceListQuery, IEnumerable<Race>>
    {
        private readonly IRaceRepository raceRepository;

        public GetRaceListQueryHandler(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public IEnumerable<Race> Handle(GetRaceListQuery query)
        {
            return this.raceRepository.GetRace();
        }
    }
}
