using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class teacher
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Position")]
        public string position { get; set; }
        [Display(Name = "Phone no")]
        public string phoneNo { get; set; }
        [Display(Name = "Teaching Hour Per Week")]
        public string hour { get; set; }
        public int ?courseId { get; set; }
        [ForeignKey("courseId")]
        public virtual course course { get; set; }

        [Display(Name = "Email")]
        public string TeacherEmail { get; set; }
        [NotMapped]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        List<teacher> list = new List<teacher>();
        public List<teacher> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                teacher tea = new teacher();
                tea.id = Convert.ToInt32(dt.Rows[i]["id"]);
                tea.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                if (dt.Columns.Contains("CourseName"))
                {
                    tea.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                tea.position = dt.Rows[i]["position"].ToString();
                tea.phoneNo = dt.Rows[i]["phoneNo"].ToString();
                tea.hour = dt.Rows[i]["hour"].ToString();
                tea.TeacherEmail = dt.Rows[i]["TeacherEmail"].ToString();
                list.Add(tea);
            }
            return list;

        }

        public static implicit operator teacher(List<teacher> v)
        {
            throw new NotImplementedException();
        }
    }
}