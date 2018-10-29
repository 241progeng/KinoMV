using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace KinoMV.Models
{
    public class Profession : INotifyPropertyChanged
    {
        private int prof_id;
        private string prof_name;
        private int mult_id;

        [Key]
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

        public string Prof_Name
        {
            get
            { return prof_name; }

            set
            {
                prof_name = value;
                OnPropertyChanged("Profession Name");
            }
        }

        public int Mult_ID
        {
            get
            { return mult_id; }

            set
            {
                mult_id = value;
                OnPropertyChanged("Multiple Occupation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ProfessionContext : DbContext
    {
        public ProfessionContext() : base("DefaultConnection")
        {
        }
        public DbSet<Profession> Professions { get; set; }
    }
}