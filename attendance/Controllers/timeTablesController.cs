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
    public class timeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: timeTables
        public ActionResult Index()
        {
            string sql = "Select * from timeTables join teachers on teachers.id = timeTables.teacherId join courses on courses.id = timeTables.courseId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new timeTable().List(dt);
            return View(model);
        }

        // GET: timeTables/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from timeTables join teachers on teachers.id = timeTables.teacherId join courses on courses.id = timeTables.courseId where timeTables.id = "+id+" ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new timeTable().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: timeTables/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");

            string sql2 = "Select * from teachers";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new teacher().List(dt2);
            ViewBag.teacherId = new SelectList(model2, "id", "TeacherName");


            return View();
        }

        // POST: timeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,teacherId,courseId,startTime,endTime,GroupId")] timeTable timeTable)
        {
            string sql = "Insert into timeTables (day, teacherId,courseId,startTime,endTime,GroupId) values ('" + timeTable.day + "' ,'" + timeTable.teacherId + "','" + timeTable.courseId + "','" + timeTable.startTime + "','" + timeTable.endTime + "','" + timeTable.GroupId + "' )";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: timeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from timeTables join teachers on teachers.id = timeTables.teacherId join courses on courses.id = timeTables.courseId where timeTables.id = " + id + " ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new timeTable().List(dt);

            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new course().List(dt1);
            ViewBag.courseId = new SelectList(model1, "id", "CourseName");

            string sql2 = "Select * from teachers";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new teacher().List(dt2);
            ViewBag.teacherId = new SelectList(model2, "id", "TeacherName");

            return View(model.FirstOrDefault());
        }

        // POST: timeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,teacherId,courseId,startTime,endTime,GroupId")] timeTable timeTable)
        {
            string sql = "Update timeTables Set day = '" + timeTable.day + "' , teacherId = '" + timeTable.teacherId + "', courseId  = '" + timeTable.courseId + "', startTime = '" + timeTable.startTime + "', endTime = '" + timeTable.endTime + "', GroupId = '" + timeTable.GroupId + "' where id = "+timeTable.id+" ";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: timeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from timeTables join teachers on teachers.id = timeTables.teacherId join courses on courses.id = timeTables.courseId where timeTables.id = " + id + " ";
            db.List(sql);
            var dt = db.List(sql);
            var model = new timeTable().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: timeTables/Delete/5
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
