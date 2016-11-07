using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int TimeElapsedInMinutes { get; set; }

        public int CountOfEmployees { get; set; }

    }
}