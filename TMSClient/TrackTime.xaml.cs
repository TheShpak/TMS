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
using TMSClient.Models;
using TMSClient.Providers;

namespace TMSClient
{
    /// <summary>
    /// Interaction logic for TrackTime.xaml
    /// </summary>
    public partial class TrackTime : Page
    {
        DataProvider provider = DataProvider.Provider;
        public TrackTime()
        {
            InitializeComponent();
            LoadComboBoxesData();
        }

        

        private async void LoadComboBoxesData()
        {
            List<EmployeeDTO> employees = await provider.GetEmployees();

            comboBoxEmployees.Items.Clear();
            foreach (EmployeeDTO employee in employees)
            {
                comboBoxEmployees.Items.Add(employee);
            }

            List<ProjectDTO> projects = await provider.GetProjects();

            comboBoxProjects.Items.Clear();
            foreach (ProjectDTO project in projects)
            {
                comboBoxProjects.Items.Add(project);
            }

            lblWaiting.Content = "";
        }

        private async void btnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            DateTime timeStart = new DateTime();
            DateTime timeEnd = new DateTime();
            try
            {
                timeStart = DateTime.Parse(datePickerStart.Text + " " + txtBoxTimeStart.Text);
                timeEnd = DateTime.Parse(datePickerEnd.Text + " " + txtBoxTimeEnd.Text);

                if ((int)((TimeSpan)(timeEnd-timeStart)).TotalMinutes < 0)
                {
                    lblError.Content = "Task time is less than 0";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Content = "Incorrect time format";
                return;
            }
            ProjectTask newTask = new ProjectTask {     Name = textBoxName.Text,
                                                        Description = textBoxDescription.Text,
                                                        EmployeeID = ((EmployeeDTO)comboBoxEmployees.SelectedItem).ID,
                                                        ProjectID = ((ProjectDTO)comboBoxProjects.SelectedItem).ID,
                                                        TimeStart = timeStart,
                                                        TimeEnd = timeEnd };
            await provider.CreateTasktAsync(newTask);
            await provider.Refresh();
            lblError.Foreground = new SolidColorBrush(Colors.Green);
            lblError.Content = "New task created";
        }
    }
}
