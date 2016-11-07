using System;
using System.Collections.Generic;

namespace TMSClient.Models
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

        public override string ToString()
        {
            return $"{ID}:{Name}:{(int)((TimeSpan)(TimeEnd - TimeStart)).TotalMinutes} min";
        }
    }
}