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
        public string name {get; set; }
        public string code { get; set; }
        public string creditHour { get; set; }
    }
}