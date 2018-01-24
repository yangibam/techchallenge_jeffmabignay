using System;
using System.Collections.Generic;
using System.Linq;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.RACE;
using WH.RACEDAY.CORE.VIEWMODELS.RACE;
using WH.RACEDAY.DAL.INTERFACES;


namespace WH.RACEDAY.RULE.QUERYHANDLER.RACE
{
    public class GetRaceDetailsQueryHandler : IQueryHandler<GetRaceDetailsQuery, RaceDetailsViewModel>
    {
        private readonly IRaceRepository raceRepository;

        public GetRaceDetailsQueryHandler(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public RaceDetailsViewModel Handle(GetRaceDetailsQuery query)
        {
            var race = this.raceRepository.GetRace().Where(r => r.ID == query.ID).FirstOrDefault();

            if (race != null)
            {
                var bets = this.raceRepository.GetBet().Where(b => b.RaceId == query.ID);

                var details = new RaceDetailsViewModel();

                details.TotalBets = bets.Sum(b => b.Stake);

                var horses = new List<HorseViewModel>();


                foreach (var horse in race.Horses)
                {
                    var horseBet = bets.Where(b => b.HorseId == horse.ID).Sum(s => s.Stake);
                    var payout = horseBet * horse.Odds;

                    horses.Add(new HorseViewModel { ID = horse.ID, Name = horse.Name, Bets = horseBet, Odds = horse.Odds, Payout = payout });
                }

                details.Horses = horses;

                return details; 
            }

            return null;
        }

        

        
    }
}
