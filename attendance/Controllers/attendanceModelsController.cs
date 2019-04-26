using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using attendance.Models;

namespace attendance.Controllers
{
    [Authorize(Roles = "Admin , Teacher. Student Services")]
    public class attendanceModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: attendanceModels
        public ActionResult Index()
        {
            string sql = "Select * from attendanceModels join timeTables on timeTables.id = attendanceModels.timeTableId join students on students.id = attendanceModels.studentId join courses on courses.id = timeTables.courseId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new attendanceModel().List(dt);
            return View(model);
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
            string sql1 = "Select * from students";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new student().List(dt1);
            ViewBag.studentId = new SelectList(model1, "id", "StudentName");

            string sql2 = "Select * from timeTables";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new timeTable().List(dt2);
            ViewBag.timeTableId = new SelectList(model2, "id", "day");
            return View();
        }
        public ActionResult SelectClass()
        {
            string sql2 = "Select * from timeTables";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new timeTable().List(dt2);
            ViewBag.timeTableId = new SelectList(model2, "id", "TimeDay");
            ViewBag.startTime = new SelectList(model2, "startTime", "startTime");
            return View();
        }
        public ActionResult FilterData()
        {
           
            return View();
        }
        public ActionResult FilterDataInd()
        {
            string sql2 = "Select * from students";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model1 = new student().List(dt2);
            ViewBag.studentId = new SelectList(model1, "id", "StudentName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterView(string select, string studentId)
        {
            DateTime date = DateTime.Now; 
            int year = date.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DayOfWeek day = date.DayOfWeek;
            CultureInfo cul = CultureInfo.CurrentCulture;
            int weekNo = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (weekNo - 1) * 7;
            DateTime dt1 = firstDay.AddDays(days);
            DayOfWeek dow = dt1.DayOfWeek;
            DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);
            string sql = "";
            if(select == "1"){
                 sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date = '" + date.ToString("dd/MM/yyyy")+"'  ";
            }if(select== "2"){
                sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date Between '" + startDateOfWeek.ToString("dd/MM/yyyy") + "' and '"+ endDateOfWeek.ToString("dd/MM/yyyy") + "'";
            }if (select == "3") {
                sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date Like '__/" + date.ToString("MM/yyyy")+ "%' ";
            }
            db.List(sql);
            var dt = db.List(sql);
            var model = new attendanceModel().List(dt);
            ViewBag.filterView = model.ToArray();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterViewInd(string select, string studentId)
        {
            DateTime date = DateTime.Now;
            int year = date.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DayOfWeek day = date.DayOfWeek;
            CultureInfo cul = CultureInfo.CurrentCulture;
            int weekNo = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (weekNo - 1) * 7;
            DateTime dt1 = firstDay.AddDays(days);
            DayOfWeek dow = dt1.DayOfWeek;
            DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);
            string sql = "";
            if (select == "1")
            {
                sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date = '" + date.ToString("dd/MM/yyyy") + "' and students.id = '" + studentId + "' ";
            }
            if (select == "2")
            {
                sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date Between '" + startDateOfWeek.ToString("dd/MM/yyyy") + "' and '" + endDateOfWeek.ToString("dd/MM/yyyy") + "' and students.id = '" + studentId + "'";
            }
            if (select == "3")
            {
                sql = "SELECT * FROM attendanceModels join students on students.id = attendanceModels.studentId join timeTables on timeTables.id = attendanceModels.timeTableId join courses on courses.id = timeTables.courseId WHERE date Like '__/" + date.ToString("MM/yyyy") + "%' and students.id = '" + studentId + "'";
            }
            db.List(sql);
            var dt = db.List(sql);
            var model = new attendanceModel().List(dt);
            ViewBag.filterView = model.ToArray();
            return View("FilterView");
        }
        public ActionResult AbsentStudent()
        {
            DateTime date = DateTime.Now;
            int year = date.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DayOfWeek day = date.DayOfWeek;
            CultureInfo cul = CultureInfo.CurrentCulture;
            int weekNo = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (weekNo - 1) * 7;
            DateTime dt1 = firstDay.AddDays(days);
            DayOfWeek dow = dt1.DayOfWeek;
            DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);
            string sql2 = "Select * from students left join attendanceModels on attendanceModels.studentId = students.id  " +
                "join facultyCourses on facultyCourses.facultyId = students.facultyId " +
                "join courses on courses.id = facultyCourses.courseId " +
                "where Not exists ( select * from  attendanceModels where attendanceModels.studentId = students.id ) and attendanceModels.date Between '" + startDateOfWeek.ToString("dd/MM/yyyy") + "' and '" + endDateOfWeek.ToString("dd/MM/yyyy") + "'  or (attendanceModels.status = 'A')";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model = new student().List(dt2);
            ViewBag.Absent = model.ToArray();
            return View();
        }
        //select routine post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectClass([Bind(Include = "timeTableId")] attendanceModel attendanceModel, string timeTableid)
        {
            string sql = "Select timeTables.id as id, students.id as StudentIDs, students.StudentName, courses.id, courses.courseName, timeTables.day, timeTables.startTime from timeTables join students on students.groupId = timeTables.groupId join courses on  timeTables.courseId = courses.id  where( timeTables.id = '" + timeTableid + "')";
            db.List(sql);
            var dt = db.List(sql);
            var model = new attendanceModel().List(dt);
            ViewBag.take = model.ToArray();
            return View("Take");
        }
        // POST: attendanceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,remarks,date,status,studentId,timeTableId")] attendanceModel attendanceModel)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            Console.WriteLine(dateTime.ToString("dd/MM/yyyy"));
            attendanceModel att = new attendanceModel();
            att.count = int.Parse(Request.Form["count"]);

            for (int i = 1; i < att.count; i++) {
                att.studentId = int.Parse(Request.Form["studentId_"+i+""]);
                att.timeTableId = int.Parse(Request.Form["timeTableId_" + i + ""]);
                att.remarks = Request.Form["remarks_" + i + ""];
                att.status = Request.Form["status_" + i + ""];
                string sql = "Insert into attendanceModels (studentId,timeTableId,date,status, Remarks) values ('" + att.studentId + "','" + att.timeTableId + "','" + dateTime.ToString("dd/MM/yyyy") + "','" + att.status + "','" + att.remarks + "')";
                db.Insert(sql);
           }
           
            return RedirectToAction("Index");
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
            ViewBag.studentId = new SelectList(db.Students, "id", "StudentName", attendanceModel.studentId);
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
            ViewBag.studentId = new SelectList(db.Students, "id", "StudentName", attendanceModel.studentId);
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
            string sql = "Delete from attendanceModels where id = " + id + "";
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
