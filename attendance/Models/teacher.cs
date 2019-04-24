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
        public string name { get; set; }
        public string position { get; set; }
        public int ?courseId { get; set; }
        [ForeignKey("courseId")]
        public virtual course course { get; set; }
        public int userId { get; set; }
      
    }
}