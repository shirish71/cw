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
        public string day { get; set; }
        public int teacherId { get; set; }
        public int courseId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("teacherId")]
        public virtual teacher teac { get; set; }
        [ForeignKey("courseId")]
        public virtual course cours { get; set; }
    }
}