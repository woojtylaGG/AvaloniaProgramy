using Avalonia.Controls;
using System.Collections.ObjectModel;
using System.IO;
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
    public void OnAddAnswerClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(AnswerTextBox.Text))
        {
            answers.Add(new Answer { Text = AnswerTextBox.Text });
            AnswerTextBox.Clear();
        }
    }
    public void OnSaveSurveyClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string fileName = $"Survey.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var question in questions)
            {
                writer.WriteLine(question);
                foreach (var answer in answers)
                {
                    writer.WriteLine($"- {answer.Text} (Checked: {answer.IsChecked})");
                }
            }
        }
    }
    
}
public class Answer
{
    public string Text { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}