using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WH.RACEDAY.CORE.ENTITIES.RACE;
using WH.RACEDAY.CORE.INTERFACES;
using WH.RACEDAY.CORE.QUERIES.RACE;
using WH.RACEDAY.CORE.VIEWMODELS.RACE;

namespace WH.RACEDAY.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryProcessor queryProcessor;

        public HomeController(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        public ActionResult Index()
        {
            var races = this.queryProcessor.Execute<List<Race>>(new GetRaceListQuery());

            ViewData["races"] = races;            

            return View();
        }

        public ActionResult Details(int id)
        {

            var raceDetails = this.queryProcessor.Execute<RaceDetailsViewModel>(new GetRaceDetailsQuery { ID = id });

            ViewData["raceDetails"] = raceDetails;

            return View();
        }

       
    }
}