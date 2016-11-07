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

namespace TMSClient
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnTrack_Click(object sender, RoutedEventArgs e)
        {
            TrackTime trackTime = new TrackTime();
            this.NavigationService.Navigate(trackTime);
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            Statistics statistics = new Statistics();
            this.NavigationService.Navigate(statistics);
        }

        private void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            CreateProject createProject = new CreateProject();
            this.NavigationService.Navigate(createProject);
        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee();
            this.NavigationService.Navigate(createEmployee);
        }
    }
}
