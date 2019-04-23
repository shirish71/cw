using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class attendance
    {
        public int StudentId { get; set; }
        public int courseTimeId { get; set; }
        public string punchInTime { get; set; }
        public string punchOutTime { get; set; }
        public string remarks { get; set; }
    }
}