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
    [Authorize(Roles = "Admin , Teacher. Student Services")]
    public class facultyCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: facultyCourses
        public ActionResult Index()
        {
            string sql = "Select * from facultyCourses join faculties on faculties.id = facultyCourses.facultyId join courses on courses.id = facultyCourses.courseId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new facultyCourse().List(dt);
            return View(model);
        }

        // GET: facultyCourses/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from facultyCourses join faculties on faculties.id = facultyCourses.facultyId join courses on courses.id = facultyCourses.courseId where (facultyCourses.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new facultyCourse().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: facultyCourses/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");

            string sql2 = "Select * from faculties";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new faculty().List(dt2);
            ViewBag.facultyId = new SelectList(model2, "id", "name");
            return View();
        }

        // POST: facultyCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,courseId,facultyId")] facultyCourse facultyCourse)
        {
            string sql = "Insert into facultyCourses (facultyId, courseId) values ('" + facultyCourse.facultyId + "' ,'" + facultyCourse.courseId + "' )";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: facultyCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from facultyCourses join faculties on faculties.id = facultyCourses.facultyId join courses on courses.id = facultyCourses.courseId where (facultyCourses.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new facultyCourse().List(dt);
            
            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");

            string sql2 = "Select * from faculties";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new faculty().List(dt2);
            ViewBag.facultyId = new SelectList(model2, "id", "name");
            return View(model.FirstOrDefault());
        }

        // POST: facultyCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,courseId,facultyId")] facultyCourse facultyCourse)
        {
            string sql = "Update facultyCourses Set facultyId = '" + facultyCourse.facultyId + "' , courseId = '" + facultyCourse.courseId + "' where id = "+facultyCourse.id+"";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: facultyCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from facultyCourses join faculties on faculties.id = facultyCourses.facultyId join courses on courses.id = facultyCourses.courseId where (facultyCourses.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new facultyCourse().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: facultyCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from courses where id = " + id + "";
            db.Delete(sql);
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
