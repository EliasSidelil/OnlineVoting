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
    public class VoteController : Controller
    {
        private OnlineVotingSystemDBEntities db = new OnlineVotingSystemDBEntities();

        // GET: Vote
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var tbl_vote = db.tbl_vote.Include(t => t.tbl_candidate).Include(t => t.tbl_events).Include(t => t.tbl_voter);
            return View(tbl_vote.ToList());
        }

        // GET: Vote/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vote tbl_vote = db.tbl_vote.Find(id);
            if (tbl_vote == null)
            {
                return HttpNotFound();
            }
            return View(tbl_vote);
        }

        // GET: Vote/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.tbl_candidate, "CandidateID", "FirstName");
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle");
            ViewBag.VoterID = new SelectList(db.tbl_voter, "VoterID", "FirstName");
            return View();
        }

        // POST: Vote/Create
        [AllowAnonymous]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteID,EventID,CandidateID,VoterID,VoteDateTime")] tbl_vote tbl_vote)
        {
            if (ModelState.IsValid)
            {
                db.tbl_vote.Add(tbl_vote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateID = new SelectList(db.tbl_candidate, "CandidateID", "FirstName", tbl_vote.CandidateID);
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_vote.EventID);
            ViewBag.VoterID = new SelectList(db.tbl_voter, "VoterID", "FirstName", tbl_vote.VoterID);
            return View(tbl_vote);
        }

        // GET: Vote/Edit/5
        [Authorize(Roles = "Fake")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vote tbl_vote = db.tbl_vote.Find(id);
            if (tbl_vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateID = new SelectList(db.tbl_candidate, "CandidateID", "FirstName", tbl_vote.CandidateID);
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_vote.EventID);
            ViewBag.VoterID = new SelectList(db.tbl_voter, "VoterID", "FirstName", tbl_vote.VoterID);
            return View(tbl_vote);
        }

        // POST: Vote/Edit/5
        [Authorize(Roles = "Fake")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteID,EventID,CandidateID,VoterID,VoteDateTime")] tbl_vote tbl_vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.tbl_candidate, "CandidateID", "FirstName", tbl_vote.CandidateID);
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_vote.EventID);
            ViewBag.VoterID = new SelectList(db.tbl_voter, "VoterID", "FirstName", tbl_vote.VoterID);
            return View(tbl_vote);
        }

        // GET: Vote/Delete/5
        [Authorize(Roles = "Fake")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vote tbl_vote = db.tbl_vote.Find(id);
            if (tbl_vote == null)
            {
                return HttpNotFound();
            }
            return View(tbl_vote);
        }

        // POST: Vote/Delete/5
        [Authorize(Roles = "Fake")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_vote tbl_vote = db.tbl_vote.Find(id);
            db.tbl_vote.Remove(tbl_vote);
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
