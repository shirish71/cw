using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class courseTImeTable
    {
        [Key]
        public int courseTimeId { get; set; }
        public int courseId { get; set; }
        public int timeTableId { get; set; }
    }
}