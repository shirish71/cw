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
    public class facultiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: faculties
        public ActionResult Index()
        {
            string sql = "Select * from faculties";
            db.List(sql);
            var dt = db.List(sql);
            var model = new faculty().List(dt);
            return View(model);
        }

        // GET: faculties/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from faculties where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new faculty().List(dt);
            return View(model.FirstOrDefault()); 
        }

        // GET: faculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,code,yearLong")] faculty faculty)
        {
            if (ModelState.IsValid)
            {
                //db.Faculties.Add(faculty);
                //db.SaveChanges();
                string sql = "Insert into faculties (name,code,yearLong) values ('" + faculty.name + "','" + faculty.code + "','" + faculty.yearLong + "')";
                db.Insert(sql);
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET: faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from faculties where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new faculty().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,code,yearLong")] faculty faculty)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(faculty).State = EntityState.Modified;
                //db.SaveChanges();
                string sql = "Update faculties set name = '" + faculty.name + "' , code = '" + faculty.code + "', yearLong = '" + faculty.yearLong + "' ";
                db.Insert(sql);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // GET: faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from faculties where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new faculty().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //faculty faculty = db.Faculties.Find(id);
            //db.Faculties.Remove(faculty);
            // db.SaveChanges();
            string sql = "Delete from faculties where id = " + id + "";

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
