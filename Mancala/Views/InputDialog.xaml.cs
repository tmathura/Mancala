using System;
using System.Windows;

namespace Mancala.Views
{
    public partial class InputDialog : Window
    {
        public InputDialog(string question, string defaultAnswer)
        {
            InitializeComponent();

            QuestionLabel.Content = question;
            AnswerTextBox.Text = defaultAnswer;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            AnswerTextBox.SelectAll();
            AnswerTextBox.Focus();
        }

        public string Answer => AnswerTextBox.Text;
    }
}