using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public enum ProjectStatus { inPprogress, canceled}
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}