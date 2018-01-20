using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.CUSTOMER;
using WH.RACEDAY.CORE.VIEWMODELS.CUSTOMER;

namespace WH.RACEDAY.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IQueryProcessor queryProcessor;

        public CustomerController(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }


        // GET: Customer
        public ActionResult Index()
        {
            var customers = this.queryProcessor.Execute<CustomerList>(new GetCustomerDetailsQuery());

            ViewData["customers"] = customers;

            return View();
        }
    }
}