using System.Windows;

namespace EnglishTrainer
{
    public partial class TrainingForm : Window
    {
        public TrainingForm()
        {
            InitializeComponent();
        }

        private void btnWriteAnswer_Click(object sender, RoutedEventArgs e)
        {
            var writeAnswerForm = new WriteAnswerForm();
            writeAnswerForm.ShowDialog();
        }

        private void btnMultipleChoice_Click(object sender, RoutedEventArgs e)
        {
            var multipleChoiceForm = new MultipleChoiceForm();
            multipleChoiceForm.ShowDialog();
        }

        private void btnCorrectMistake_Click(object sender, RoutedEventArgs e)
        {
            var correctMistakeForm = new CorrectMistakeForm();
            correctMistakeForm.ShowDialog();
        }
    }
}