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
    public class GenderController : Controller
    {
        private OnlineVotingSystemDBEntities db = new OnlineVotingSystemDBEntities();

        // GET: Gender
        public ActionResult Index()
        {
            return View(db.tbl_gender.ToList());
        }

        // GET: Gender/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_gender tbl_gender = db.tbl_gender.Find(id);
            if (tbl_gender == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gender);
        }

        // GET: Gender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gender/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenderID,Gender")] tbl_gender tbl_gender)
        {
            if (ModelState.IsValid)
            {
                db.tbl_gender.Add(tbl_gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_gender);
        }

        // GET: Gender/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_gender tbl_gender = db.tbl_gender.Find(id);
            if (tbl_gender == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gender);
        }

        // POST: Gender/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenderID,Gender")] tbl_gender tbl_gender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_gender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_gender);
        }

        // GET: Gender/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_gender tbl_gender = db.tbl_gender.Find(id);
            if (tbl_gender == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gender);
        }

        // POST: Gender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_gender tbl_gender = db.tbl_gender.Find(id);
            db.tbl_gender.Remove(tbl_gender);
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
