using System.Data.Entity;
using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class EmployeeWindow : Window
    {
        EmployeeContext db;
        public EmployeeWindow()
        {
            InitializeComponent();

            db = new EmployeeContext();
            db.Employees.Load();
            this.DataContext = db.Employees.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInput employee_input = new EmployeeInput(new Employee());
            if (employee_input.ShowDialog() == true)
            {
                Employee employee = employee_input.Employee;
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (employeeList.SelectedItem == null) return;
            Employee employee = employeeList.SelectedItem as Employee;

            EmployeeInput employee_input = new EmployeeInput(new Employee
            {                
                Pers_ID = employee.Pers_ID,
                Name = employee.Name,
                Surname = employee.Surname,
                Prof_ID = employee.Prof_ID,
            });

            if (employee_input.ShowDialog() == true)
            {
                employee = db.Employees.Find(employee_input.Employee.Prof_ID);
                if (employee != null)
                {                    
                    employee.Pers_ID = employee_input.Employee.Pers_ID;
                    employee.Name = employee_input.Employee.Name;
                    employee.Surname = employee_input.Employee.Surname;
                    employee.Prof_ID = employee_input.Employee.Prof_ID;

                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (employeeList.SelectedItem == null) return;
            Employee employee = employeeList.SelectedItem as Employee;
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}