using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.CUSTOMER;
using WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER;
using WH.RACEDAY.DAL.INTERFACES;

namespace WH.RACEDAY.RULE.QUERYHANDLER.CUSTOMER
{
    public class GetCustomerDetailsQueryHandler : IQueryHandler<GetCustomerDetailsQuery, CustomerListViewModel>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IRaceRepository raceRepository;

        public GetCustomerDetailsQueryHandler(ICustomerRepository customerRepository, IRaceRepository raceRepository)
        {
            this.customerRepository = customerRepository;
            this.raceRepository = raceRepository;
        }

        public CustomerListViewModel Handle(GetCustomerDetailsQuery query)
        {
            var bets = this.raceRepository.GetBet();
            var customers = this.customerRepository.GetCustomer();

            if (customers != null && customers.Count() > 0)
            {
                CustomerListViewModel customerList = new CustomerListViewModel();

                customerList.TotalBets = bets.Sum(b => b.Stake);

                var customerDetails = new List<CustomerViewModel>();

                foreach (var customer in customers)
                {
                    var customerBets = bets.Where(b => b.CustomerId == customer.ID).Sum(s => s.Stake);
                    var atRisk = customerBets > 200 ? true : false;

                    customerDetails.Add(new CustomerViewModel { ID = customer.ID, Name = customer.Name, Bet = customerBets, isAtRisk = atRisk });

                }

                customerList.Customers = customerDetails;

                return customerList; 
            }

            return null;
        }
    }
}
