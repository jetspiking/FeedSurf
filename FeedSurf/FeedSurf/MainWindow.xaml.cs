using CodeHollow.FeedReader;
using FeedSurf.Core;
using FeedSurf.Misc;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace FeedSurf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MainWindowInstance;
        public MainWindow()
        {
            MainWindow.MainWindowInstance = this;

            InitializeComponent();

            this.Closed += (object? sender, EventArgs e) =>
            {
                AppState.GetInstance().NavigatorPanel.ForceClose = true;
                System.Windows.Application.Current.Shutdown();
            };

            AppState.GetInstance().NavigatorPanel.SelectAllLabel();
        }
    }
}