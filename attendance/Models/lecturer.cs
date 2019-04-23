using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class lecturer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}