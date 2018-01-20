using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.CUSTOMER;

namespace WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER
{
    public class CustomerList
    {
        public double TotalBets { get; set; }
        public IEnumerable<CustomerDetails> Customers { get; set; }
    }
}
