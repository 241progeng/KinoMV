using System.Data.Entity;
using System.Windows;
using KinoMV.Models;

namespace KinoMV
{
    public partial class ProfessionWindow : Window
    {
        ProfessionContext db;
        public ProfessionWindow()
        {
            InitializeComponent();

            db = new ProfessionContext();
            db.Professions.Load();
            this.DataContext = db.Professions.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ProfessionInput prof_input = new ProfessionInput(new Profession());
            if (prof_input.ShowDialog() == true)
            {
                Profession prof = prof_input.Profession;
                db.Professions.Add(prof);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (profList.SelectedItem == null) return;
            Profession prof = profList.SelectedItem as Profession;

            ProfessionInput prof_input = new ProfessionInput(new Profession
            {
                Prof_ID = prof.Prof_ID,
                Prof_Name = prof.Prof_Name,
                Mult_ID = prof.Mult_ID
            });

            if (prof_input.ShowDialog() == true)
            {
                prof = db.Professions.Find(prof_input.Profession.Prof_ID);
                if (prof != null)
                {
                    prof.Prof_ID = prof_input.Profession.Prof_ID;
                    prof.Prof_Name = prof_input.Profession.Prof_Name;
                    prof.Mult_ID = prof_input.Profession.Mult_ID;
                    db.Entry(prof).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (profList.SelectedItem == null) return;
            Profession prof = profList.SelectedItem as Profession;
            db.Professions.Remove(prof);
            db.SaveChanges();
        }
    }
}