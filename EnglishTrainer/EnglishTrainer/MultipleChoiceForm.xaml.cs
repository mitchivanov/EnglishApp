using System.Windows;

namespace EnglishTrainer
{
    public partial class MultipleChoiceForm : Window
    {
        public MultipleChoiceForm()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            using (var reader = DatabaseHelper.GetMultipleChoiceQuestions())
            {
                if (reader.Read())
                {
                    lblQuestion.Text = reader["Question"].ToString();
                    rdoOption1.Content = reader["Option1"].ToString();
                    rdoOption2.Content = reader["Option2"].ToString();
                    rdoOption3.Content = reader["Option3"].ToString();
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