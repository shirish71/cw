using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class course
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName {get; set; }

        [Display(Name = "Code")]
        public string code { get; set; }

        [Display(Name = "Credit Hr")]
        public string creditHour { get; set; }


        List<course> list = new List<course>();
        public List<course> List(System.Data.DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                course cou = new course();
                cou.id = Convert.ToInt32(dt.Rows[i]["id"]);
                cou.CourseName = dt.Rows[i]["CourseName"].ToString();
                cou.code = dt.Rows[i]["code"].ToString();
                cou.creditHour = dt.Rows[i]["creditHour"].ToString();
                list.Add(cou);
            }
            return list;

        }

       
    }
}