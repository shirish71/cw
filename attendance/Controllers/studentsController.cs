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
    public class studentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: students1
        public ActionResult Index()
        {
            //var students = db.Students.Include(s => s.fac);
            // return View(students.ToList());
            string sql = "Select * from students join faculties on faculties.id = students.facultyId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new student().List(dt);
            return View(model);
        }

        // GET: students1/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from students join faculties on faculties.id = students.facultyId where (students.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new student().List(dt);
            return View(model.FirstOrDefault());
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
        public ActionResult FilterView(string courseId)
        {
            string sql = "Select * from courses join facultyCourses on facultyCourses.courseId = courses.id join faculties on faculties.id = facultyCourses.facultyId join students on facultyCourses.facultyId = students.facultyId where courses.id = " + courseId + " order By students.enrollDate asc";
            db.List(sql);
            var dt = db.List(sql);
            var model = new student().List(dt);
            ViewBag.filterView = model.ToArray();
            return View();
        }

        // GET: students1/Create
        public ActionResult Create()
        {
            string sql = "Select * from faculties";
            db.List(sql);
            var dt = db.List(sql);
            var model = new faculty().List(dt);
            ViewBag.facultyId = new SelectList(model, "id", "name");
            return View();
        }

        // POST: students1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,StudentName,phone,email,DOB,address,enrollDate,groupId,facultyId")] student student)
        {
            string sql = "Insert into students (StudentName,phone,email,DOB,address,enrollDate,groupId,facultyId) values ('" + student.StudentName + "','" + student.phone + "','" + student.email + "','" + student.DOB + "','" + student.address + "','" + student.enrollDate + "','" + student.groupId + "','" + student.facultyId + "')";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: students1/Edit/5
        public ActionResult Edit(int? id)
        {
            //string sql = "Select Students.id, StudentName, DOB, phone, email, address, groupId, facultyId as facultyId, name  from students  join faculties on faculties.id = students.facultyId where (students.id = " + id + ")";
            string sql1 = "Select * from faculties";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new faculty().List(dt1);
            ViewBag.facultyId = new SelectList(model1, "id", "name");
            string sql = "Select * from students  join faculties on faculties.id = students.facultyId where (students.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new student().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: students1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,StudentName,phone,email,DOB,address,enrollDate,groupId,facultyId")] student student)
        {
            string sql = "Update students Set StudentName = '" + student.StudentName + "' , phone = '" + student.phone + "' , email = '" + student.email + "', DOB = '" + student.DOB + "' , enrollDate = '" + student.enrollDate + "', address = '" + student.address + "', groupId = '" + student.groupId + "', facultyId = '" + student.facultyId + "' where id = " + student.id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: students1/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from students  join faculties on faculties.id = students.facultyId where (students.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new student().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.Students.Find(id);
            db.Students.Remove(student);
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
