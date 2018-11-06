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

namespace KinoMV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Prof_Click(object sender, RoutedEventArgs e)
        {
            ProfessionWindow profwindow = new ProfessionWindow();
            profwindow.Show();
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow();
            employeewindow.Show();
        }

        private void ProjectEmployee_Click(object sender, RoutedEventArgs e)
        {
            ProjectEmployeeWindow projemployeewindow = new ProjectEmployeeWindow();
            projemployeewindow.Show();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userwindow = new UserWindow();
            userwindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LogIn logwindow = new LogIn();
            logwindow.Show();
        }
    }
}
