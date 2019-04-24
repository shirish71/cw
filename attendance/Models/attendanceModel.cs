using System;
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
      
        public string remarks { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public int ?studentId { get; set; }

        [ForeignKey("studentId")]
        public virtual student stud { get; set; }

        public int ?timeTableId { get; set; }

        [ForeignKey("timeTableId")]
        public virtual timeTable timeTable { get; set; }

    }
}