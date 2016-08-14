using System.Windows;

namespace AsyncImagesDownloadApp
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }

        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (AsyncImagesDownloader.cts != null)
            {
                AsyncImagesDownloader.cts.Cancel();
            }
        }
    }
}
