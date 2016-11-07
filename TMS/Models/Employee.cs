using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}