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
    public class EventsController : Controller
    {
        private OnlineVotingSystemDBEntities db = new OnlineVotingSystemDBEntities();

        // GET: Events
        [Authorize(Roles = "Administrator,DataClerk")]
        public ActionResult Index()
        {
            return View(db.tbl_events.ToList());
        }

        // GET: Events/Details/5
        [Authorize(Roles = "Administrator,DataClerk")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_events tbl_events = db.tbl_events.Find(id);
            if (tbl_events == null)
            {
                return HttpNotFound();
            }
            return View(tbl_events);
        }

        // GET: Events/Create
        [Authorize(Roles = "DataClerk")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [Authorize(Roles = "DataClerk")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventTitle,EventDesc,StartDate,EndDate")] tbl_events tbl_events)
        {
            if (ModelState.IsValid)
            {
                db.tbl_events.Add(tbl_events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_events);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_events tbl_events = db.tbl_events.Find(id);
            if (tbl_events == null)
            {
                return HttpNotFound();
            }
            return View(tbl_events);
        }

        // POST: Events/Edit/5
        [Authorize(Roles = "Administrator")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventTitle,EventDesc,StartDate,EndDate")] tbl_events tbl_events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_events);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_events tbl_events = db.tbl_events.Find(id);
            if (tbl_events == null)
            {
                return HttpNotFound();
            }
            return View(tbl_events);
        }

        // POST: Events/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_events tbl_events = db.tbl_events.Find(id);
            db.tbl_events.Remove(tbl_events);
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
