using System.Configuration;
using System.Data;
using System.Windows;

namespace FeedSurf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Dispatcher.UnhandledException += (sender, e) =>
            {
                MessageBox.Show(e.Exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            };
        }
    }

}
