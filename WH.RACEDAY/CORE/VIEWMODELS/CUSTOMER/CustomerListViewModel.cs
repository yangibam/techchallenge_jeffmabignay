using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER
{
    public class CustomerListViewModel
    {
        public double TotalBets { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }
    }
}
