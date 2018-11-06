using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class ProjectEmployeeInput : Window
    {
        public ProjectEmployee ProjectEmployee { get; private set; }

        public ProjectEmployeeInput(ProjectEmployee p)
        {
            InitializeComponent();
            ProjectEmployee = p;
            this.DataContext = ProjectEmployee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
