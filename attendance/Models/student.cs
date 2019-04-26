using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class student
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Enroll Date")]
        public string enrollDate { get; set; }

        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Group Id")]
        public string groupId { get; set; }

        [NotMapped]
        [Display(Name = "Faculty Name")]
        public string name { get; set; }
        [NotMapped]
        [Display(Name = "Course Name")]
        public string courseName { get; set; }
        [NotMapped]
        [Display(Name = "Course Id")]
        public string courseId { get; set; }
        public int facultyId { get; set; }
        [ForeignKey ("facultyId")]
        public virtual faculty fac { get; set; }

        List<student> list = new List<student>();
        public List<student> List(System.Data.DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                student stu = new student();
                stu.id = Convert.ToInt32(dt.Rows[i]["id"]);
                stu.StudentName = dt.Rows[i]["StudentName"].ToString();
                if (dt.Columns.Contains("name")) {
                    stu.name = dt.Rows[i]["name"].ToString();
                }
                if (dt.Columns.Contains("CourseName"))
                {
                    stu.courseName = dt.Rows[i]["CourseName"].ToString();
                }
                stu.phone = dt.Rows[i]["phone"].ToString();
                stu.email = dt.Rows[i]["email"].ToString();
                stu.DOB = dt.Rows[i]["DOB"].ToString();
                stu.address = dt.Rows[i]["address"].ToString();
                stu.enrollDate = dt.Rows[i]["enrollDate"].ToString();
                stu.groupId = dt.Rows[i]["groupId"].ToString();

                list.Add(stu);
            }
            return list;

        }

    }
}