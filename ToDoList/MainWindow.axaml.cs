using Avalonia.Controls;
using Avalonia.Interactivity;
namespace ToDoList;
using System.Collections.ObjectModel;
using System.Linq;

public partial class MainWindow : Window{

    private ObservableCollection<ToDoTask> tasks = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        TasksListBox.ItemsSource = tasks;
        FilterComboBox.SelectionChanged += FilterComboBox_SelectionChanged;
    }
    private void AddTask_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NewTaskDescription.Text))
        {
            tasks.Add(new ToDoTask { Description = NewTaskDescription.Text, IsCompleted = false });
            NewTaskDescription.Text = string.Empty;
        }
    }
    private void RemoveTask_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is ToDoTask task)
        {
            tasks.Remove(task);
        }
    }
    private void FilterComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedFilter = (FilterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
        if (selectedFilter == "All")
        {
            TasksListBox.ItemsSource = tasks;
        }
        else if (selectedFilter == "Done")
        {
            TasksListBox.ItemsSource = tasks.Where(t => t.IsCompleted).ToList();
        }
        else if (selectedFilter == "To do")
        {
            TasksListBox.ItemsSource = tasks.Where(t => !t.IsCompleted).ToList();
        }
    }
}