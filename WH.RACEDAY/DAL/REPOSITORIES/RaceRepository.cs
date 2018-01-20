using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.RACE;
using WH.RACEDAY.DAL.INTERFACES;
using RestSharp;

namespace WH.RACEDAY.DAL.REPOSITORIES
{
    public class RaceRepository : IRaceRepository
    {
        private RestClient client;

        public IEnumerable<Bet> GetBet()
        {
            this.client = new RestClient(Config.GetServiceBaseURL());

            var resource = "GetBetsV2?Name=jeff";

            var request = new RestRequest(resource, Method.GET);

            var response = this.client.Execute<List<Bet>>(request);

            return response.Data;
        }

        

        public IEnumerable<Race> GetRace()
        {
            this.client = new RestClient(Config.GetServiceBaseURL());

            var resource = "GetRaces?Name=jeff";

            var request = new RestRequest(resource, Method.GET);

            var response = this.client.Execute<List<Race>>(request);

            return response.Data;
        }
    }
}
