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
    public class attendanceModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: attendanceModels
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.stud).Include(a => a.timeTable);
            return View(attendances.ToList());
        }

        // GET: attendanceModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendanceModel attendanceModel = db.Attendances.Find(id);
            if (attendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(attendanceModel);
        }

        // GET: attendanceModels/Create
        public ActionResult Create()
        {
            ViewBag.studentId = new SelectList(db.Students, "id", "name");
            ViewBag.timeTableId = new SelectList(db.TimeTables, "id", "day");
            return View();
        }

        // POST: attendanceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,remarks,date,status,studentId,timeTableId")] attendanceModel attendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendanceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentId = new SelectList(db.Students, "id", "name", attendanceModel.studentId);
            ViewBag.timeTableId = new SelectList(db.TimeTables, "id", "day", attendanceModel.timeTableId);
            return View(attendanceModel);
        }

        // GET: attendanceModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendanceModel attendanceModel = db.Attendances.Find(id);
            if (attendanceModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentId = new SelectList(db.Students, "id", "name", attendanceModel.studentId);
            ViewBag.timeTableId = new SelectList(db.TimeTables, "id", "day", attendanceModel.timeTableId);
            return View(attendanceModel);
        }

        // POST: attendanceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,remarks,date,status,studentId,timeTableId")] attendanceModel attendanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentId = new SelectList(db.Students, "id", "name", attendanceModel.studentId);
            ViewBag.timeTableId = new SelectList(db.TimeTables, "id", "day", attendanceModel.timeTableId);
            return View(attendanceModel);
        }

        // GET: attendanceModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendanceModel attendanceModel = db.Attendances.Find(id);
            if (attendanceModel == null)
            {
                return HttpNotFound();
            }
            return View(attendanceModel);
        }

        // POST: attendanceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attendanceModel attendanceModel = db.Attendances.Find(id);
            db.Attendances.Remove(attendanceModel);
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
