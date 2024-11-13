using Avalonia.Controls;
using Avalonia.Interactivity;
namespace ToDoList;
using System.Collections.ObjectModel;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private ObservableCollection<ToDoTask> tasks = new();
    private void AddTask_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NewTaskDescription.Text))
        {
            tasks.Add(new ToDoTask { Description = NewTaskDescription.Text, IsCompleted = false });
            NewTaskDescription.Text = string.Empty;
        }
    }
}