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
    /// Interaction logic for CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Page
    {
        DataProvider provider = DataProvider.Provider;
        public CreateEmployee()
        {
            InitializeComponent();
        }

        private async void btnCreateEnployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee
            {
                Name = textBoxName.Text
            };

            await provider.CreateEmployeeAsync(employee);
            await provider.Refresh();

            lblCreated.Foreground = new SolidColorBrush(Colors.Green);
            lblCreated.Content = "New employee created";
        }
    }
}
