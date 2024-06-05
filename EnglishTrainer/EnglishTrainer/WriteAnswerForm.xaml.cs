using System.Windows;

namespace EnglishTrainer
{
    public partial class WriteAnswerForm : Window
    {
        public WriteAnswerForm()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            using (var reader = DatabaseHelper.GetWriteAnswerQuestions())
            {
                if (reader.Read())
                {
                    lblQuestion.Text = reader["Question"].ToString();
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