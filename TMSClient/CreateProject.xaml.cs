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
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Page
    {
        DataProvider provider = DataProvider.Provider;
        public CreateProject()
        {
            InitializeComponent();
        }

        private async void btnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            Project project = new Project
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                Status = ProjectStatus.inPprogress
            };

            await provider.CreateProjectAsync(project);
            await provider.Refresh();

            lblCreated.Foreground = new SolidColorBrush(Colors.Green);
            lblCreated.Content = "New project created";
        }
    }
}
