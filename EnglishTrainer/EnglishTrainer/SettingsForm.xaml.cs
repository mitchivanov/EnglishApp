using System.Windows;

namespace EnglishTrainer
{
    public partial class SettingsForm : Window
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void trackBarBrightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = trackBarBrightness.Value / 100.0;
        }

        private void chkFullscreen_Checked(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }

        private void chkFullscreen_Unchecked(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.WindowState = WindowState.Normal;
        }
    }
}