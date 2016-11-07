using System;
using System.Collections.Generic;

namespace TMSClient.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }

        public override string ToString()
        {
            return $"{ID}:{Name}";
        }
    }
}