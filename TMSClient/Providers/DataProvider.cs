using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TMSClient.Models;

namespace TMSClient.Providers
{
    
    class DataProvider
    {
        private static DataProvider provider;
        private static HttpClient client = new HttpClient();

        private static List<ProjectDTO> projects;
        private static List<EmployeeDTO> employees;
        private static List<ProjectTask> tasks;

        private DataProvider()
        {
            //Api Base address
            client.BaseAddress = new Uri("http://localhost:57392/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static DataProvider Provider
        {
            get
            {
                if (provider == null)
                {
                    provider = new DataProvider();
                }
                return provider;
            }
        }

        public async Task<string> Refresh()
        {
            HttpResponseMessage response = await client.GetAsync("api/projecttasks");
            if (response.IsSuccessStatusCode)
            {
                //Getting the result and mapping to a Product object
                tasks = await response.Content.ReadAsAsync<List<ProjectTask>>();
                Console.WriteLine("Success1");
                Console.WriteLine(tasks.Count);
            }
            else
            {
                Console.WriteLine("Failed1");
            }

            response = await client.GetAsync("api/projects");
            if (response.IsSuccessStatusCode)
            {
                //Getting the result and mapping to a Product object
                projects = await response.Content.ReadAsAsync<List<ProjectDTO>>();
                Console.WriteLine("Success2");
                Console.WriteLine(projects.Count);
            }
            else
            {
                Console.WriteLine("Failed2");
            }

            response = await client.GetAsync("api/employees");
            if (response.IsSuccessStatusCode)
            {
                //Getting the result and mapping to a Product object
                employees = await response.Content.ReadAsAsync<List<EmployeeDTO>>();
                Console.WriteLine("Success3");
                Console.WriteLine(employees.Count);
            }
            else
            {
                Console.WriteLine("Failed3");
            }

            return "ok";
        }
        public async Task<List<ProjectTask>> GetTasks()
        {
            if (tasks == null)
            {
                await Refresh();
            }
            return tasks;

        }

        public async Task<List<ProjectDTO>> GetProjects()
        {
            if (projects == null)
            {
                await Refresh();
            }
            return projects;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            if (employees == null)
            {
                await Refresh();
            }
            return employees;

        }

        
        public async Task<Uri> CreateTasktAsync(ProjectTask projectTask)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/ProjectTasks", projectTask);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<Uri> CreateProjectAsync(Project project)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/projects", project);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        public async Task<Uri> CreateEmployeeAsync(Employee employee)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        static async Task<List<ProjectTask>> GetProductAsync(string path)
        {
            List<ProjectTask> employees = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<List<ProjectTask>>();
            }
            return employees;
        }
        
        /*
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:57392/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("Hi");

            List<ProjectTask> employees = await GetProductAsync("http://localhost:57392/api/test");
            ShowProduct(employees);

            Console.ReadLine();
            
            ProjectTask projectTask = new ProjectTask { Name = "NewTask", Description = "Description for new task", EmployeeID = 3, ProjectID = 3, TimeStart = DateTime.Parse("2016-09-16 12:15:00"), TimeEnd = DateTime.Parse("2016-09-16 13:15:00") };

            var url = await CreateTaskAsync(projectTask);
            Console.WriteLine($"Created at {url}");

            Console.ReadLine();

            List<ProjectTask> employees2 = await GetProductAsync("http://localhost:57392/api/ProjectTasks");
            ShowProduct(employees2);

            Console.ReadLine();
        
        }*/
    }
}
