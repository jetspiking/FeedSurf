using CodeHollow.FeedReader;
using FeedSurf.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeedSurf.Interface
{
    /// <summary>
    /// Interaction logic for FeedSelectionItem.xaml
    /// </summary>
    public partial class FeedSelectionItem : UserControl
    {
        private AppState _appState;        

        public FeedSelectionItem(RssFeed rssFeed)
        {
            InitializeComponent();

            this.FeedLabel.Content = rssFeed.Name;

            this._appState = AppState.GetInstance();

            this.FeedLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.FeedLabel.FontFamily = this._appState.LocalThemeConfiguration.NavigatorFeedFontFamily;
            this.FeedLabel.FontSize = this._appState.LocalThemeConfiguration.NavigatorFeedFontSize;
            this.FeedLabel.FontWeight = this._appState.LocalThemeConfiguration.NavigatorFeedFontWeight;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            if (String.IsNullOrEmpty(rssFeed.ImageUrl)) return;
            bitmap.UriSource = new Uri(rssFeed.ImageUrl, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            this.FeedImage.Source = bitmap;

            this.MouseEnter += (object sender, MouseEventArgs e) =>
            {
                this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupBackgroundColor);
            };
            this.MouseLeave += (object sender, MouseEventArgs e) =>
            {
                this.Background = null;
            };
        }

        public void SelectItem()
        {
            this.FeedLabel.Foreground = _appState._navigatorSelectColorBrush;
        }

        public void DeselectItem()
        {
            this.FeedLabel.Foreground = _appState._navigatorDeselectColorBrush;
        }

        
    }
}
