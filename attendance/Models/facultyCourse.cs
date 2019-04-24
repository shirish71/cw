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
        public int ?courseId { get; set; }
        public int ?facultyId { get; set; }

        [ForeignKey("courseId")]
        public virtual course cou { get; set; }
        [ForeignKey("facultyId")]
        public virtual faculty fac { get; set; }
    }
}