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
    public class facultyCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: facultyCourses
        public ActionResult Index()
        {
            string sql = "Select * from facultyCourses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new facultyCourse().List(dt);
            return View(model);
        }

        // GET: facultyCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyCourse facultyCourse = db.FacultyCourses.Find(id);
            if (facultyCourse == null)
            {
                return HttpNotFound();
            }
            return View(facultyCourse);
        }

        // GET: facultyCourses/Create
        public ActionResult Create()
        {
            ViewBag.courseId = new SelectList(db.Courses, "id", "name");
            ViewBag.facultyId = new SelectList(db.Faculties, "id", "name");
            return View();
        }

        // POST: facultyCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,courseId,facultyId")] facultyCourse facultyCourse)
        {
            if (ModelState.IsValid)
            {
                db.FacultyCourses.Add(facultyCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseId = new SelectList(db.Courses, "id", "name", facultyCourse.courseId);
            ViewBag.facultyId = new SelectList(db.Faculties, "id", "name", facultyCourse.facultyId);
            return View(facultyCourse);
        }

        // GET: facultyCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyCourse facultyCourse = db.FacultyCourses.Find(id);
            if (facultyCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = new SelectList(db.Courses, "id", "name", facultyCourse.courseId);
            ViewBag.facultyId = new SelectList(db.Faculties, "id", "name", facultyCourse.facultyId);
            return View(facultyCourse);
        }

        // POST: facultyCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,courseId,facultyId")] facultyCourse facultyCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseId = new SelectList(db.Courses, "id", "name", facultyCourse.courseId);
            ViewBag.facultyId = new SelectList(db.Faculties, "id", "name", facultyCourse.facultyId);
            return View(facultyCourse);
        }

        // GET: facultyCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facultyCourse facultyCourse = db.FacultyCourses.Find(id);
            if (facultyCourse == null)
            {
                return HttpNotFound();
            }
            return View(facultyCourse);
        }

        // POST: facultyCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facultyCourse facultyCourse = db.FacultyCourses.Find(id);
            db.FacultyCourses.Remove(facultyCourse);
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
