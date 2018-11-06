using System.Data.Entity;
using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class ProjectEmployeeWindow : Window
    {
        ProjectEmployeeContext db;
        public ProjectEmployeeWindow()
        {
            InitializeComponent();

            db = new ProjectEmployeeContext();
            db.ProjectEmployees.Load();
            this.DataContext = db.ProjectEmployees.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ProjectEmployeeInput projemployee_input = new ProjectEmployeeInput(new ProjectEmployee());
            if (projemployee_input.ShowDialog() == true)
            {
                ProjectEmployee projemployee = projemployee_input.ProjectEmployee;
                db.ProjectEmployees.Add(projemployee);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (projemployeeList.SelectedItem == null) return;
            ProjectEmployee projemployee = projemployeeList.SelectedItem as ProjectEmployee;

            ProjectEmployeeInput projemployee_input = new ProjectEmployeeInput(new ProjectEmployee
            {                
                Proj_ID = projemployee.Proj_ID,
                Pers_ID = projemployee.Pers_ID,
            });

            if (projemployee_input.ShowDialog() == true)
            {
                projemployee = db.ProjectEmployees.Find(projemployee_input.ProjectEmployee.Proj_ID);
                if (projemployee != null)
                {
                    projemployee.Proj_ID = projemployee_input.ProjectEmployee.Proj_ID;
                    projemployee.Pers_ID = projemployee_input.ProjectEmployee.Pers_ID;                    
                    db.Entry(projemployee).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (projemployeeList.SelectedItem == null) return;
            ProjectEmployee projemployee = projemployeeList.SelectedItem as ProjectEmployee;
            db.ProjectEmployees.Remove(projemployee);
            db.SaveChanges();
        }
    }
}