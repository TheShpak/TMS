﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMSClient.Models
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalTimeInMinutes { get; set; }

        public override string ToString()
        {
            return $"{ID}:{Name}";
        }

    }
}