using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class attendanceModel
    {
        [Key]
        public int id { get; set; }


        public string date { get; set; }
        public string status { get; set; }
        public int? studentId { get; set; }

        [ForeignKey("studentId")]
        public virtual student stud { get; set; }

        public int? timeTableId { get; set; }
        public string remarks { get; set; }

        [ForeignKey("timeTableId")]
        public virtual timeTable timeTable { get; set; }

        [NotMapped]
        public string StudentName { get; set; }
        [NotMapped]
        public int StudentIDs { get; set; }
        [NotMapped]
        public int count { get; set; }
        [NotMapped]
        public string day { get; set; }
        [NotMapped]
        public string startTime { get; set; }
        [NotMapped]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        List<attendanceModel> list = new List<attendanceModel>();
        public List<attendanceModel> List(System.Data.DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                attendanceModel attend = new attendanceModel();
                attend.id = Convert.ToInt32(dt.Rows[i]["id"]);
                if (dt.Columns.Contains("date"))
                {
                    attend.date = dt.Rows[i]["date"].ToString();
                }
                if (dt.Columns.Contains("day"))
                {
                    attend.date = dt.Rows[i]["day"].ToString();
                }
                if (dt.Columns.Contains("status"))
                {
                    attend.status = dt.Rows[i]["status"].ToString();
                }
                if (dt.Columns.Contains("StudentName"))
                {
                    attend.StudentName = dt.Rows[i]["StudentName"].ToString();
                }
                if (dt.Columns.Contains("StudentIDs"))
                {
                    attend.StudentIDs = Convert.ToInt32(dt.Rows[i]["StudentIDs"]);
                }
                if (dt.Columns.Contains("startTime"))
                {
                    attend.startTime = dt.Rows[i]["startTime"].ToString();
                }
                if (dt.Columns.Contains("remarks"))
                {
                    attend.remarks = dt.Rows[i]["remarks"].ToString();
                }
                if (dt.Columns.Contains("CourseName"))
                {
                    attend.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                list.Add(attend);
            }
            return list;

        }


    }
    
}