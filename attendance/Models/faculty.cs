using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace attendance.Models
{
    public class faculty
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Faculty Name")]
        public string name { get; set; }
        public string code { get; set;  }
        [Display(Name = "Year Long")]
        public string yearLong { get; set; }

        List<faculty> list = new List<faculty>();
        public List<faculty> List(System.Data.DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                faculty fac = new faculty();
                fac.id = Convert.ToInt32(dt.Rows[i]["id"]);
                fac.name = dt.Rows[i]["name"].ToString();
                fac.code = dt.Rows[i]["code"].ToString();
                fac.yearLong = dt.Rows[i]["yearLong"].ToString();
                list.Add(fac);
            }
            return list;

        }
    }
}