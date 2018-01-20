using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.CUSTOMER;
using WH.RACEDAY.DAL.INTERFACES;

namespace WH.RACEDAY.DAL.REPOSITORIES
{
    public class CustomerRepository : ICustomerRepository
    {
        private RestClient client;

        public IEnumerable<Customer> GetCustomer()
        {
            this.client = new RestClient(Config.GetServiceBaseURL());

            var resource = "GetCustomers?name=jeff";

            var request = new RestRequest(resource, Method.GET);

            var response = this.client.Execute<List<Customer>>(request);

            return response.Data;
        }
    }
}
