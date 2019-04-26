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
    public class teachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: teachers
        public ActionResult Index()
        {
            string sql = "Select * from teachers join courses on teachers.courseId = courses.id";
            db.List(sql);
            var dt = db.List(sql);
            var model = new teacher().List(dt);

            return View(model);
        }
        public ActionResult FilterData()
        {
            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterView([Bind(Include = "id,TeacherName,position,courseId,hour,TeacherEmail,phoneNo")] teacher teacher, string courseId)
        {
            string sql = "Select * from courses join teachers on courses.id = teachers.courseId where courses.id = "+courseId+"";
            db.List(sql);
            var dt = db.List(sql);
            var model = new teacher().List(dt);
            ViewBag.filterView = model.ToArray();
            return View();
        }

        // GET: teachers/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from teachers join courses on teachers.courseId = courses.id where (teachers.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new teacher().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: teachers/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TeacherName,position,courseId,hour,TeacherEmail,phoneNo")] teacher teacher)
        {
            string sql = "Insert into teachers (TeacherName, position,courseId,TeacherEmail,hour,phoneNo) values ('" + teacher.TeacherName + "' ,'" + teacher.position + "','" + teacher.courseId + "','" + teacher.TeacherEmail + "' ,'" + teacher.hour + "','" + teacher.phoneNo + "' )";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from teachers join courses on teachers.courseId = courses.id where (teachers.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new teacher().List(dt);

            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");
            return View(model.FirstOrDefault());
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TeacherName,position,courseId,phoneNo,hour,TeacherEmail")] teacher teacher)
        {
            string sql = "Update teachers Set TeacherName = '" + teacher.TeacherName + "', position = '" + teacher.position + "' , courseId = '" + teacher.courseId + "',  hour = '" + teacher.hour + "' ,TeacherEmail = '" + teacher.TeacherEmail + "' ,phoneNo = '" + teacher.phoneNo + "'  where id = " + teacher.id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from teachers join courses on teachers.courseId = courses.id where (teachers.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new teacher().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: teachers/Delete/5
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
