using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Bet { get; set; }
        public bool isAtRisk { get; set; }
    }
}
