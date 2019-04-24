using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class student
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string phone { get; set; }
        
        public string email { get; set; }
        public string DOB { get; set; }
        public string address { get; set; }
        public string groupId { get; set; }
        public int ?facultyId { get; set; }
        [ForeignKey ("facultyId")]
        public virtual faculty fac { get; set; }

    
    }
}