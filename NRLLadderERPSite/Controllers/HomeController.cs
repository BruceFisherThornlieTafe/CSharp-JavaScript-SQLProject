using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NRLLadderERPSite.Controllers
{
    public class HomeController : Controller
    {
        // Home Page View
        public ActionResult Index()
        {
            return View();
        }

        // About Page View
        public ActionResult About()
        {
            ViewBag.Message = "NRL Ladder application description page.";

            return View();
        }

        // Contact Page View
        public ActionResult Contact()
        {
            ViewBag.Message = "NRL contact page.";

            return View();
        }
    }
}