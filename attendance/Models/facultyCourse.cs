using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class facultyCourse
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int courseId { get; set; }
       
        [ForeignKey("courseId")]
        public virtual course cou { get; set; }
        public int facultyId { get; set; }
        
        [ForeignKey("facultyId")]
        public virtual faculty fac { get; set; }

        List<facultyCourse> list = new List<facultyCourse>();
        public List<facultyCourse> List(System.Data.DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                facultyCourse facCou = new facultyCourse();
                facCou.id = Convert.ToInt32(dt.Rows[i]["id"]);
                facCou.courseId = Convert.ToInt32(dt.Rows[i]["courseId"]);
                facCou.facultyId = Convert.ToInt32(dt.Rows[i]["facultyId"]);
                
                list.Add(facCou);
            }
            return list;

        }
    }
}