using Avalonia.Controls;
using System.Collections.ObjectModel;
namespace Survey_Creator;

public partial class MainWindow : Window
{
    private ObservableCollection<Answer> answers = new();
    private ObservableCollection<string> questions = new();
    public MainWindow()
    {
        InitializeComponent();
        AnswersListBox.ItemsSource = answers;
        QuestionsListBox.ItemsSource = questions;
        DataContext = this;
    }
    public void OnAddQuestionClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(QuestionTextBox.Text))
        {
            string questionType = SingleChoiceRadioButton.IsChecked == true ? "Single Choice" : "Multiple Choice";
            string question = $"{QuestionTextBox.Text} ({questionType})";
            questions.Add(question);
            QuestionTextBox.Clear();
            answers.Clear();
        }
    }
}