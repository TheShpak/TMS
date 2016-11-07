using System;
using System.Collections.Generic;

namespace TMSClient.Models
{
    public enum ProjectStatus { inPprogress, canceled}
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }

        public override string ToString()
        {
            return $"{ID}:{Name}";
        }
    }
}