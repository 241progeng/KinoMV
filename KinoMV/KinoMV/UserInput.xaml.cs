using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class UserInput : Window
    {
        public User User { get; private set; }

        public UserInput(User p)
        {
            InitializeComponent();
            User = p;
            this.DataContext = User;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}