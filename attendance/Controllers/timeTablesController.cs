using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using attendance.Models;

namespace attendance.Controllers
{
    public class timeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: timeTables
        public ActionResult Index()
        {
            return View(db.TimeTables.ToList());
        }

        // GET: timeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: timeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: timeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,TeacherId,CourseId,startTime,endTime,GroupId")] timeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeTable);
        }

        // GET: timeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: timeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,TeacherId,CourseId,startTime,endTime,GroupId")] timeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeTable);
        }

        // GET: timeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: timeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            timeTable timeTable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timeTable);
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
