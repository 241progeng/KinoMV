using System.Linq;
using System.Data.Entity;
using KinoMV.Models;
using System.Windows;
using System.Diagnostics;

namespace KinoMV
{
    public partial class LogIn : Window
    {
        UserContext db;

        public LogIn()
        {
            InitializeComponent();

            db = new UserContext();
            db.Users.Load();
            this.DataContext = db.Users.Local.ToBindingList();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string un = UsernameBox.Text;
            string pw = User.MD5Hash(User.MD5Hash(PasswordBox.Password));
            var users = (from u in db.Users where u.Username == un select u).ToList();

            Debug.WriteLine(un);
            Debug.WriteLine(pw);
            Debug.WriteLine(users.FirstOrDefault<User>().Username);
            Debug.WriteLine(users.FirstOrDefault<User>().Password);
            
            if (users.Count() == 0)
            {
                MessageBox.Show("Error");
            }

            else
            {
                if(pw == users.FirstOrDefault<User>().Password)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }

                else
                {
                    ErrorMessage err = new ErrorMessage();
                    err.Show();
                }
            }
        }
    }
}
