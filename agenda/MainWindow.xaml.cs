using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace agenda
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Event> Events { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            eventListBox.ItemsSource = Events;

            // Appel à une méthode pour initialiser les ComboBox
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            // Ajout des heures dans le ComboBox cmbStartHour
            for (int hour = 0; hour < 24; hour++)
            {
                cmbStartHour.Items.Add(hour);
            }

            // Ajout des minutes dans le ComboBox cmbStartMinute
            for (int minute = 0; minute < 60; minute++)
            {
                cmbStartMinute.Items.Add(minute);
            }
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le titre de l'événement
            string title = txtTitle.Text;

            // Récupérer la date sélectionnée
            DateTime date = dpDate.SelectedDate ?? DateTime.Now;

            // Récupérer l'heure de début sélectionnée
            int? startHour = cmbStartHour.SelectedItem as int?;
            int? startMinute = cmbStartMinute.SelectedItem as int?;

            // Vérifier que les valeurs ne sont pas null
            if (startHour == null || startMinute == null)
            {
                // Afficher un message d'erreur ou gérer le cas où les valeurs sont null
                // Vous pouvez par exemple afficher un MessageBox ou ignorer l'ajout de l'événement
                MessageBox.Show("Veuillez sélectionner une heure de début valide.");
                return;
            }

            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, startHour.Value, startMinute.Value, 0);

            // Ajouter l'événement à la liste
            Event newEvent = new Event { Title = title, Date = startTime };
            Events.Add(newEvent);

            // Effacer les champs de saisie après l'ajout de l'événement
            txtTitle.Text = string.Empty;
            dpDate.SelectedDate = null;
            cmbStartHour.SelectedIndex = 0;
            cmbStartMinute.SelectedIndex = 0;
        }
    }

    public class Event
    {
        public string Title { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
