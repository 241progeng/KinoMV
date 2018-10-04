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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;

namespace _1
{

    public class Profession
    {
        private int prof_id;
        private string prof_name;
        private bool mult_id;

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

        public bool Mult_ID
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

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Profession> Professions { get; set; }
    }

    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Professions.Load();
            this.DataContext = db.Professions.Local.ToBindingList();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            InputPage inputpage = new InputPage(new Profession());
            if (inputpage.ShowDialog() == true)
            {
                Profession prof = inputpage.Profession;
                db.Professions.Add(prof);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (profList.SelectedItem == null) return;
            // получаем выделенный объект
            Profession prof = profList.SelectedItem as Profession;

            InputPage inputpage = new InputPage(new Profession
            {
                Prof_ID = prof.Prof_ID,
                Prof_Name = prof.Prof_Name,
                Mult_ID = prof.Mult_ID
            });

            if (inputpage.ShowDialog() == true)
            {
                // получаем измененный объект
                prof = db.Professions.Find(inputpage.Profession.Prof_ID);
                if (prof != null)
                {
                    prof.Prof_ID = inputpage.Profession.Prof_ID;
                    prof.Prof_Name = inputpage.Profession.Prof_Name;
                    prof.Mult_ID = inputpage.Profession.Mult_ID;
                    db.Entry(prof).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (profList.SelectedItem == null) return;
            // получаем выделенный объект
            Profession prof = profList.SelectedItem as Profession;
            db.Professions.Remove(prof);
            db.SaveChanges();
        }
    }
}

