using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Event_Calendar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddEventButton.Click += AddEventButton_Click;
        }

        private void AddEventButton_Click(object? sender, RoutedEventArgs e)
        {
            var eventName = EventNameTextBox.Text;
            if (!string.IsNullOrEmpty(eventName))
            {
                if (ImportantCheckBox.IsChecked == true)
                {
                    eventName = "[Ważne] " + eventName;
                }
                EventsListBox.Items.Add(eventName);
                EventNameTextBox.Text = string.Empty; 
                ImportantCheckBox.IsChecked = false; 
            }
        }
    }
}