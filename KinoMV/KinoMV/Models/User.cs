using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;

namespace KinoMV.Models
{
    public class User : INotifyPropertyChanged
    {
        #region

        private string name;
        private string surname;
        private string username;
        private int mode;
        private string password;

        [Key]
        public string Name
        {
            get
            {   return name;    }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            { return surname; }

            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string UserName
        {
            get
            { return username; }

            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public int Mode
        {
            get
            { return mode; }

            set
            {
                mode = value;
                OnPropertyChanged("Mode");
            }
        }

        public string Password
        {
            get
            { return password; }

            set
            {
                password = MD5Hash(value);
                OnPropertyChanged("Mode");
            }
        }

        public static string MD5Hash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {                  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
        public class UserContext : DbContext
        {
            public UserContext() : base("DefaultConnection")
            {
            }
            public DbSet<User> Users { get; set; }
        }
    }
}