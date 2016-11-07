using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using TMSClient.Providers;
using TMSClient.Models;

namespace TMSClient
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        DataProvider provider = DataProvider.Provider;
        public Statistics()
        {
            InitializeComponent();
            ShowData();
        }


        
        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await provider.Refresh();
            ShowData();
        }

        private async void ShowData()
        {
            List<ProjectTask> tasks = await provider.GetTasks();

            tasksBox.Items.Clear();
            foreach (ProjectTask task in tasks)
            {
                tasksBox.Items.Add(task);
            }

            List<ProjectDTO> projects = await provider.GetProjects();

            projectsBox.Items.Clear();
            foreach (ProjectDTO project in projects)
            {
                projectsBox.Items.Add(project);
            }

            List<EmployeeDTO> employees = await provider.GetEmployees();

            employeesBox.Items.Clear();
            foreach (EmployeeDTO employee in employees)
            {
                employeesBox.Items.Add(employee);
            }

            lblWaiting.Content = "";
        }

        private async void btnLoadProjects_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void btnLoadEmployees_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTaskDetails_Click(object sender, RoutedEventArgs e)
        {
            if (tasksBox.SelectedItem == null)
            {
                return;
            }
            ProjectTask task = (ProjectTask)tasksBox.SelectedItem;

            detailsTextBox.Text =   "ID: " + task.ID + "\n" +
                                    "Task name: " + task.Name + "\n" +
                                    "Description: " + task.Description + "\n" +
                                    "Project name: " + task.Project.Name + "\n" +
                                    "Employee name: " + task.Employee.Name + "\n" +
                                    "Start time: " + task.TimeStart + "\n" +
                                    "End time: " + task.TimeEnd + "\n" +                                    
                                    "Time elapsed: " + (int)((TimeSpan)(task.TimeEnd - task.TimeStart)).TotalMinutes + "min";
        }

        private void btnProjectDetails_Click(object sender, RoutedEventArgs e)
        {
            if (projectsBox.SelectedItem == null)
            {
                return;
            }
            ProjectDTO project = (ProjectDTO)projectsBox.SelectedItem;

            

            detailsTextBox.Text = "ID: " + project.ID + "\n" +
                                    "Project name: " + project.Name + "\n" +
                                    "Description: " + project.Description + "\n" +
                                    "Total time assigned to the project: " + project.TimeElapsedInMinutes + " min\n" +
                                    "Count of employees on the project: " + project.CountOfEmployees;
        }

        private void btnEmployeeDetails_Click(object sender, RoutedEventArgs e)
        {
            if (employeesBox.SelectedItem == null)
            {
                return;
            }
            EmployeeDTO employee = (EmployeeDTO)employeesBox.SelectedItem;

           

            detailsTextBox.Text = "ID: " + employee.ID + "\n" +
                                    "Task name: " + employee.Name + "\n" +
                                    "Total time elapsed by the employee: " + employee.TotalTimeInMinutes + " min";
        }
    }
}
