using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class courseTeacherViewModel
    {
        public IEnumerable< teacher> teachers { get; set; }
        public IEnumerable<course> courses { get; set; }
    }
}