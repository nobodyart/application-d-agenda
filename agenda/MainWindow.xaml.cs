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
        }

       private void AddEvent_Click(object sender, RoutedEventArgs e)
{
    // Afficher une boîte de dialogue pour saisir le titre de l'événement
    string title = Microsoft.VisualBasic.Interaction.InputBox("Entrez le titre de l'événement", "Nouvel Événement", "");

    // Vérifier si l'utilisateur a annulé la saisie
    if (string.IsNullOrEmpty(title))
        return;

    DateTime date = dpDate.SelectedDate ?? DateTime.Now; // Utilisez la date actuelle si aucune date n'est sélectionnée

    Event newEvent = new Event { Title = title, Date = date };
    Events.Add(newEvent);

    // Efface les champs de saisie après l'ajout de l'événement
    txtTitle.Text = string.Empty;
    dpDate.SelectedDate = null;
}

    }

    public class Event
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
