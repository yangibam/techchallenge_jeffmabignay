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
    public class GetBetListQueryHandler : IQueryHandler<GetBetListQuery, IEnumerable<Bet>>
    {
        private readonly IRaceRepository raceRepository;

        public GetBetListQueryHandler(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public IEnumerable<Bet> Handle(GetBetListQuery query)
        {
            var bets = this.raceRepository.GetBet();

            return bets;
        }
    }
}
