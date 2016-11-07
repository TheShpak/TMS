using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TMS.Models;

namespace TMS.DAL
{
    public class TMSInitializer : System.Data.Entity.DropCreateDatabaseAlways<TMSContext>
    {
        protected override void Seed(TMSContext context)
        {
            var projects = new List<Project>
            {
            new Project{ ID = 1, Name="Project1", Description = "Description for project 1", Status = ProjectStatus.inPprogress},
            new Project{ ID = 2, Name="Project2", Description = "Description for project 2", Status = ProjectStatus.inPprogress},
            new Project{ ID = 3, Name="Project3", Description = "Description for project 3", Status = ProjectStatus.inPprogress}
            };

            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();
            var employees = new List<Employee>
            {
            new Employee{ID=1, Name= "John Snow" },
            new Employee{ID=2, Name= "Harry Potter" },
            new Employee{ID=3, Name= "Sam Winchester" },
            new Employee{ID=4, Name= "Gregory House" },
            new Employee{ID=5, Name= "Albert Einstein" }
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            var tasks = new List<ProjectTask>
            {
            new ProjectTask { ID=1, Name ="Task1", Description="Task 1-1", EmployeeID=1, ProjectID=1, TimeStart = DateTime.Parse("2016-09-16 12:15:00"), TimeEnd = DateTime.Parse("2016-09-16 13:15:00")},
            new ProjectTask { ID=2, Name ="Task2", Description="Task 2-1", EmployeeID=2, ProjectID=1, TimeStart = DateTime.Parse("2016-09-16 15:40:00"), TimeEnd = DateTime.Parse("2016-09-16 16:00:00")},
            new ProjectTask { ID=3, Name ="Task3", Description="Task 2-3", EmployeeID=1, ProjectID=3, TimeStart = DateTime.Parse("2016-09-16 13:15:00"), TimeEnd = DateTime.Parse("2016-09-16 14:00:00")},
            new ProjectTask { ID=4, Name ="Task4", Description="Task 5-2", EmployeeID=5, ProjectID=2, TimeStart = DateTime.Parse("2016-09-16 16:00:00"), TimeEnd = DateTime.Parse("2016-09-16 18:00:00")}
            };
            tasks.ForEach(s => context.Tasks.Add(s));
            context.SaveChanges();
        }
    }
}



