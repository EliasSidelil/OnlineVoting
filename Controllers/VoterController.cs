using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVoting;

namespace OnlineVoting.Controllers
{
    [Authorize]
    public class VoterController : Controller
    {
        private OnlineVotingSystemDBEntities db = new OnlineVotingSystemDBEntities();

        // GET: Voter
        [Authorize(Roles = "Administrator,DataClerk")]
        public ActionResult Index()
        {
            var tbl_voter = db.tbl_voter.Include(t => t.tbl_events).Include(t => t.tbl_gender);
            return View(tbl_voter.ToList());
        }

        // GET: Voter/Details/5
        [Authorize(Roles = "Administrator,DataClerk")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voter tbl_voter = db.tbl_voter.Find(id);
            if (tbl_voter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_voter);
        }

        // GET: Voter/Create
        [Authorize(Roles = "DataClerk")]
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle");
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender");
            return View();
        }

        // POST: Voter/Create
        [Authorize(Roles = "DataClerk")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoterID,EventID,GenderID,FirstName,LastName,Department")] tbl_voter tbl_voter)
        {
            if (ModelState.IsValid)
            {
                db.tbl_voter.Add(tbl_voter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_voter.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_voter.GenderID);
            return View(tbl_voter);
        }

        // GET: Voter/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voter tbl_voter = db.tbl_voter.Find(id);
            if (tbl_voter == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_voter.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_voter.GenderID);
            return View(tbl_voter);
        }

        // POST: Voter/Edit/5
        [Authorize(Roles = "Administrator")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoterID,EventID,GenderID,FirstName,LastName,Department")] tbl_voter tbl_voter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_voter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_voter.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_voter.GenderID);
            return View(tbl_voter);
        }

        // GET: Voter/Delete/5
        [Authorize(Roles = "Fake")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_voter tbl_voter = db.tbl_voter.Find(id);
            if (tbl_voter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_voter);
        }

        // POST: Voter/Delete/5
        [Authorize(Roles = "Fake")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_voter tbl_voter = db.tbl_voter.Find(id);
            db.tbl_voter.Remove(tbl_voter);
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
