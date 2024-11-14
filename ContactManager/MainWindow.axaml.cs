using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace ContactManager;
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> Contacts { get; } = new ObservableCollection<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            ContactsListBox.ItemsSource = Contacts;
            FilterComboBox.SelectedIndex = 0;
        }

        private void OnAddEditButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var contact = new Contact
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text,
                IsFavorite = FavoriteCheckBox.IsChecked ?? false
            };

            Contacts.Add(contact);
            ClearInputFields();
            ApplyFilterAndSort();
        }
        private void OnFilterChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilterAndSort();
        }
    }
}