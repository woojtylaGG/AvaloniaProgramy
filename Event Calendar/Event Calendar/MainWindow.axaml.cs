using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
namespace Event_Calendar
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<string>> events;
        public MainWindow()
        {
            InitializeComponent();
            events = new Dictionary<string, List<string>>();
            AddEventButton.Click += AddEventButton_Click;
            UpdateWindowButton.Click += UpdateWindowButton_Click;
        }

        private void AddEventButton_Click(object? sender, RoutedEventArgs e)
        {
            var eventName = EventNameTextBox.Text;
            var selectedDay = (DayOfWeekComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var isImportant = ImportantCheckBox.IsChecked ?? false;
            
            if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(selectedDay))
            {
                if (isImportant)
                {
                    eventName = "[Ważne] " + eventName;
                }
                
                if (!events.ContainsKey(selectedDay))
                {
                    events[selectedDay] = new List<string>();
                }
                events[selectedDay].Add(eventName);

                UpdateEventsListBox(selectedDay);

                EventNameTextBox.Text = string.Empty;
                ImportantCheckBox.IsChecked = false;
            }
        }

        private void UpdateWindowButton_Click(object? sender, RoutedEventArgs e)
        {
            var selectedDay = (DayOfWeekComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!string.IsNullOrEmpty(selectedDay))
            {
                UpdateEventsListBox(selectedDay);
            }
        }

        private void UpdateEventsListBox(string dayOfWeek)
        {
            EventsListBox.ItemsSource = events.ContainsKey(dayOfWeek) ? events[dayOfWeek] : new List<string>();
        }
    }
}