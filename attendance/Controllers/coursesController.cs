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
    public class coursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: courses
        public ActionResult Index()
        {
            string sql = "Select * from courses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new course().List(dt);
            return View(model);
        }

        // GET: courses/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new course().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CourseName,code,creditHour")] course course)
        {
            if (ModelState.IsValid)
            {
                //db.Courses.Add(course);
                // db.SaveChanges();
                string sql = "Insert into courses (CourseName,code,creditHour) values ('" + course.CourseName + "','" + course.code + "','" + course.creditHour + "')";
                db.Insert(sql);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: courses/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new course().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CourseName,code,creditHour")] course course)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update courses set CourseName = '" + course.CourseName + "' , code = '" + course.code + "', creditHour = '" + course.creditHour + "' where id = " + course.id + "";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: courses/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new course().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: courses/Delete/5
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

