using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace KinoMV.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private int pers_id;
        private string name;
        private string surname;
        private int prof_id;

        [Key]
        public int Pers_ID
        {
            get
            { return pers_id; }

            set
            {
                pers_id = value;
                OnPropertyChanged("Personal ID");
            }
        }

        public string Name
        {
            get
            { return name; }

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

        public int Prof_ID
        {
            get
            { return prof_id; }

            set
            {
                prof_id = value;
                OnPropertyChanged("Profession ID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("DefaultConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}