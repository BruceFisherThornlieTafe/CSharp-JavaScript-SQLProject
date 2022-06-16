using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NRLLadderERPSite.Models;

namespace NRLLadderERPSite.Controllers
{
    public class TeamsController : Controller
    {
        private nrlladder_erpEntities db = new nrlladder_erpEntities();

        // GET: Teams
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Ladder).Include(t => t.Season);
            return View(teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            ViewBag.PK_TeamId = new SelectList(db.Ladders, "PKFK_TeamID", "PKFK_TeamID");
            ViewBag.PK_TeamId = new SelectList(db.Seasons, "PKFK_TeamID", "PKFK_TeamID");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_TeamId,Name,Played,Points,Wins,Draw,Lost,Byes")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PK_TeamId = new SelectList(db.Ladders, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            ViewBag.PK_TeamId = new SelectList(db.Seasons, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.PK_TeamId = new SelectList(db.Ladders, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            ViewBag.PK_TeamId = new SelectList(db.Seasons, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_TeamId,Name,Played,Points,Wins,Draw,Lost,Byes")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PK_TeamId = new SelectList(db.Ladders, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            ViewBag.PK_TeamId = new SelectList(db.Seasons, "PKFK_TeamID", "PKFK_TeamID", team.PK_TeamId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
