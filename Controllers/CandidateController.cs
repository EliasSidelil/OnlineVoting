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
    public class CandidateController : Controller
    {
        private OnlineVotingSystemDBEntities db = new OnlineVotingSystemDBEntities();

        // GET: Candidate
        [AllowAnonymous]
        public ActionResult Index()
        {
            var tbl_candidate = db.tbl_candidate.Include(t => t.tbl_events).Include(t => t.tbl_gender);
            return View(tbl_candidate.ToList());
        }

        // GET: Candidate/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_candidate tbl_candidate = db.tbl_candidate.Find(id);
            if (tbl_candidate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_candidate);
        }

        // GET: Candidate/Create
        [Authorize(Roles = "DataClerk")]
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle");
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender");
            return View();
        }

        // POST: Candidate/Create
        [Authorize(Roles = "DataClerk")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateID,EventID,GenderID,FirstName,LastName,BirthDate,Department")] tbl_candidate tbl_candidate)
        {
            if (ModelState.IsValid)
            {
                db.tbl_candidate.Add(tbl_candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_candidate.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_candidate.GenderID);
            return View(tbl_candidate);
        }

        // GET: Candidate/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_candidate tbl_candidate = db.tbl_candidate.Find(id);
            if (tbl_candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_candidate.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_candidate.GenderID);
            return View(tbl_candidate);
        }

        // POST: Candidate/Edit/5
        [Authorize(Roles = "Administrator")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,EventID,GenderID,FirstName,LastName,BirthDate,Department")] tbl_candidate tbl_candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.tbl_events, "EventID", "EventTitle", tbl_candidate.EventID);
            ViewBag.GenderID = new SelectList(db.tbl_gender, "GenderID", "Gender", tbl_candidate.GenderID);
            return View(tbl_candidate);
        }

        // GET: Candidate/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_candidate tbl_candidate = db.tbl_candidate.Find(id);
            if (tbl_candidate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_candidate);
        }

        // POST: Candidate/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_candidate tbl_candidate = db.tbl_candidate.Find(id);
            db.tbl_candidate.Remove(tbl_candidate);
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
