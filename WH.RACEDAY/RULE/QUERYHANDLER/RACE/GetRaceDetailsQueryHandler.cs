using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.RACE;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.RACE;
using WH.RACEDAY.CORE.VIEWMODELS.RACE;
using WH.RACEDAY.DAL.INTERFACES;

namespace WH.RACEDAY.RULE.QUERYHANDLER.RACE
{
    public class GetRaceDetailsQueryHandler : IQueryHandler<GetRaceDetailsQuery, RaceDetails>
    {
        private readonly IRaceRepository raceRepository;

        public GetRaceDetailsQueryHandler(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public RaceDetails Handle(GetRaceDetailsQuery query)
        {
            var race = this.raceRepository.GetRace().Where(r => r.ID == query.ID).FirstOrDefault();
            var bets = this.raceRepository.GetBet().Where(b => b.RaceId == query.ID);

            var details = new RaceDetails();

            details.TotalBets = bets.Sum(b => b.Stake);

            var horses = new List<HorseDetails>();


            foreach(var horse in race.Horses)
            {
                var horseBet = bets.Where(b => b.HorseId == horse.ID).Sum(s => s.Stake);
                var payout = horseBet * horse.Odds;

                horses.Add(new HorseDetails { ID = horse.ID, Name = horse.Name, Bets = horseBet, Odds = horse.Odds, Payout = payout });

            }

            details.Horses = horses;

            return details;
        }

        
    }
}
