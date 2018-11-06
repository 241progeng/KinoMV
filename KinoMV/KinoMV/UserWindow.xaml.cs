using System.Data.Entity;
using System.Linq;
using System.Windows;
using KinoMV.Models;
using System.Diagnostics;

namespace KinoMV
{
    public partial class UserWindow : Window
    {
        UserContext db;
        public UserWindow()
        {
            InitializeComponent();

            db = new UserContext();
            db.Users.Load();
            this.DataContext = db.Users.Local.ToBindingList();

            var users = (from u in db.Users select u).ToList();
            foreach(var user in users)
            {
                Debug.WriteLine(user.Password);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserInput user_input = new UserInput(new User());
            if (user_input.ShowDialog() == true)
            {
                var users = (from u in db.Users where u.Username == user_input.User.Username select u).ToList().Count();                
                if (users == 0)
                {
                    db.Users.Add(user_input.User);
                    db.SaveChanges();
                }

                else
                {
                    ErrorMessage err = new ErrorMessage();
                    err.Show();
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (userList.SelectedItem == null) return;
            User user = userList.SelectedItem as User;

            UserInput user_input = new UserInput(new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Mode = user.Mode,
                Password = user.Password,
        });

            if (user_input.ShowDialog() == true)
            {
                user = db.Users.Find(user_input.User.Username);
                if (user != null)
                {
                    user.Name = user_input.User.Name;
                    user.Surname = user_input.User.Surname;
                    user.Username = user_input.User.Username;
                    user.Mode = user_input.User.Mode;
                    user.Password = user_input.User.Password;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (userList.SelectedItem == null) return;
            User user = userList.SelectedItem as User;
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}