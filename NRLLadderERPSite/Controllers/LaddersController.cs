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
    public class LaddersController : Controller
    {
        private nrlladder_erpEntities db = new nrlladder_erpEntities();

        // GET: Ladders
        public ActionResult Index()
        {
            var ladders = db.Ladders.Include(l => l.Team);
            return View(ladders.ToList());
        }

        // GET: Ladders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ladder ladder = db.Ladders.Find(id);
            if (ladder == null)
            {
                return HttpNotFound();
            }
            return View(ladder);
        }

        // GET: Ladders/Create
        public ActionResult Create()
        {
            ViewBag.PKFK_TeamID = new SelectList(db.Teams, "PK_TeamId", "Name");
            return View();
        }

        // POST: Ladders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKFK_TeamID,Position,Ladder_Dif")] Ladder ladder)
        {
            if (ModelState.IsValid)
            {
                db.Ladders.Add(ladder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PKFK_TeamID = new SelectList(db.Teams, "PK_TeamId", "Name", ladder.PKFK_TeamID);
            return View(ladder);
        }

        // GET: Ladders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ladder ladder = db.Ladders.Find(id);
            if (ladder == null)
            {
                return HttpNotFound();
            }
            ViewBag.PKFK_TeamID = new SelectList(db.Teams, "PK_TeamId", "Name", ladder.PKFK_TeamID);
            return View(ladder);
        }

        // POST: Ladders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKFK_TeamID,Position,Ladder_Dif")] Ladder ladder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ladder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PKFK_TeamID = new SelectList(db.Teams, "PK_TeamId", "Name", ladder.PKFK_TeamID);
            return View(ladder);
        }

        // GET: Ladders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ladder ladder = db.Ladders.Find(id);
            if (ladder == null)
            {
                return HttpNotFound();
            }
            return View(ladder);
        }

        // POST: Ladders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ladder ladder = db.Ladders.Find(id);
            db.Ladders.Remove(ladder);
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
