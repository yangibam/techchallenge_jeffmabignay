using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RACEDAY.CORE.ENTITIES.CUSTOMER;

namespace WH.RACEDAY.DAL.INTERFACES
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer();
    }
}
