using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class timeTable
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Day")]
        public string day { get; set; }

        public int teacherId { get; set; }
        public int courseId { get; set; }

        [Display(Name = "Start Time")]
        public string startTime { get; set; }

        [Display(Name = "End Time")]
        public string endTime { get; set; }
        public string GroupId { get; set; }

        [NotMapped]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Teacher Name")]
        [NotMapped]
        public string TeacherName { get; set; }
        [NotMapped]
        public string StudentName { get; set; }
        [NotMapped]
        public string TimeDay { get; set; }
        [ForeignKey("teacherId")]
        public virtual teacher teac { get; set; }
        [ForeignKey("courseId")]
        public virtual course cours { get; set; }

        List<timeTable> list = new List<timeTable>();
        public List<timeTable> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                timeTable tim = new timeTable();
                tim.id = Convert.ToInt32(dt.Rows[i]["id"]);
                if (dt.Columns.Contains("TeacherName"))
                {
                    tim.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                }
                if (dt.Columns.Contains("StudentName"))
                {
                    tim.StudentName = dt.Rows[i]["StudentName"].ToString();
                }
                if (dt.Columns.Contains("CourseName"))
                {
                    tim.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                tim.day = dt.Rows[i]["day"].ToString();
                tim.startTime = dt.Rows[i]["startTime"].ToString();
                tim.endTime = dt.Rows[i]["endTime"].ToString();
                tim.GroupId = dt.Rows[i]["GroupId"].ToString();
                if (dt.Columns.Contains("day"))
                {
                    tim.TimeDay = tim.day +" "+ tim.startTime;
                }
                list.Add(tim);
            }
            return list;

        }
    }
}