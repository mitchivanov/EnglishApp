using System.Windows;
using System.Data;

namespace EnglishTrainer
{
    public partial class ResultsForm : Window
    {
        public ResultsForm()
        {
            InitializeComponent();
            LoadResults();
        }

        private void LoadResults()
        {
            var results = new DataTable();
            results.Columns.Add("UserName");
            results.Columns.Add("CorrectAnswers");
            results.Columns.Add("TimeSpent");

            using (var reader = DatabaseHelper.GetResults())
            {
                while (reader.Read())
                {
                    var row = results.NewRow();
                    row["UserName"] = reader["UserName"].ToString();
                    row["CorrectAnswers"] = reader["CorrectAnswers"].ToString();
                    row["TimeSpent"] = reader["TimeSpent"].ToString();
                    results.Rows.Add(row);
                }
            }

            resultsList.ItemsSource = results.DefaultView;
        }
    }
}