using System;
using System.Collections.Generic;

namespace TMSClient.Models
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int TimeElapsedInMinutes { get; set; }

        public int CountOfEmployees { get; set; }

        public override string ToString()
        {
            return $"{ID}:{Name}:{Description}";
        }

    }
}