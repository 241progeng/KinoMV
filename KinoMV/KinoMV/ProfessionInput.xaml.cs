using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class ProfessionInput : Window
    {
        public Profession Profession { get; private set; }

        public ProfessionInput(Profession p)
        {
            InitializeComponent();
            Profession = p;
            this.DataContext = Profession;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}