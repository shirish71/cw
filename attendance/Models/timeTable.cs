using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class timeTable
    {
        [Key]
        public int id { get; set; }
        public string day { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}