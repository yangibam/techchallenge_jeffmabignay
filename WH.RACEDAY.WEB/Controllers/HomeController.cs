﻿using System;
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
        private readonly ICommandProcessor commandProcessor;

        public HomeController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this.queryProcessor = queryProcessor;
            this.commandProcessor = commandProcessor;
        }

        public ActionResult Index()
        {
            var races = this.queryProcessor.Execute<IEnumerable<Race>>(new GetRaceListQuery());

            ViewData["races"] = races;            

            return View();
        }

        public ActionResult Details(int id)
        {

            var raceDetails = this.queryProcessor.Execute<RaceDetails>(new GetRaceDetailsQuery { ID = id });

            ViewData["raceDetails"] = raceDetails;

            return View();
        }

       
    }
}