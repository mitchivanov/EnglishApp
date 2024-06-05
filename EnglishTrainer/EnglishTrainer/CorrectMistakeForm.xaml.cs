using System.Windows;

namespace EnglishTrainer
{
    public partial class CorrectMistakeForm : Window
    {
        public CorrectMistakeForm()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            using (var reader = DatabaseHelper.GetCorrectMistakeQuestions())
            {
                if (reader.Read())
                {
                    lblIncorrectText.Text = reader["IncorrectText"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Логика проверки ответа и сохранения результата
            this.Close();
        }
    }
}