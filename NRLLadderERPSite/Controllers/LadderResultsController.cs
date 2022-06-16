using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NRLLadderERPSite.Models;

namespace NRLLadderERPSite.Controllers
{
    public class LadderResultsController : Controller
    {
        // Access Database
        private nrlladder_erpEntities db = new nrlladder_erpEntities();

        // GET: LadderResults
        public ActionResult Index()
        {
            // Load all data from Tables in Lists
            List<Team> teamlist = db.Teams.ToList();
            List<Season> seasonlist = db.Seasons.ToList();
            List<Ladder> ladderlist = db.Ladders.ToList();

            // In case if not all data is entered in the Tables
            try
            {
                // Join all List Data Together matched with given Keys
                ViewData["jointables"] = from t in teamlist
                                         join s in seasonlist on t.PK_TeamId equals s.PKFK_TeamID into table1
                                         from s in table1.DefaultIfEmpty()
                                         join l in ladderlist on s.PKFK_TeamID equals l.PKFK_TeamID into table2
                                         from l in table2.DefaultIfEmpty()
                                         select new LadderResults { teamlist = t, seasonlist = s, ladderlist = l };
            }
            catch
            {
                // stop crash
            }
            // Return joined Lists as a View
            return View(ViewData["jointables"]);
        }
    }
}