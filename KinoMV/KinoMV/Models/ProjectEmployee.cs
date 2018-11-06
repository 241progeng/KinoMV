using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace KinoMV.Models
{
    public class ProjectEmployee : INotifyPropertyChanged
    {
        private int proj_id;
        private int pers_id;

        [Key]
        public int Proj_ID
        {
            get
            { return proj_id; }

            set
            {
                proj_id = value;
                OnPropertyChanged("Profession ID");
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ProjectEmployeeContext : DbContext
    {
        public ProjectEmployeeContext() : base("DefaultConnection")
        {
        }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    }
}