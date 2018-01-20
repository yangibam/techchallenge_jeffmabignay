using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.CUSTOMER;

namespace WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER
{
    public class CustomerDetails: Customer
    {
        public int Bet { get; set; }
        public bool isAtRisk { get; set; }
    }
}
