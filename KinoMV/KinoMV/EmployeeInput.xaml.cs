using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class EmployeeInput : Window
    {
        public Employee Employee { get; private set; }

        public EmployeeInput(Employee e)
        {
            InitializeComponent();
            Employee = e;
            this.DataContext = Employee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
