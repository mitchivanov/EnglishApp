using System.Windows;

namespace EnglishTrainer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void btnTraining_Click(object sender, RoutedEventArgs e)
        {
            var trainingForm = new TrainingForm();
            trainingForm.ShowDialog();
        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}