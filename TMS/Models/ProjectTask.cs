using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class ProjectTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
    }
}