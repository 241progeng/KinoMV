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

namespace _1
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public Profession Profession { get; private set; }

        public InputPage (Profession p)
        {
            InitializeComponent();
            Profession = p;
            this.DataContext = Profession;
        }
 
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult() = true;
        }
    }
}
