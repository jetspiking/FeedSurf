using CodeHollow.FeedReader;
using FeedSurf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for FeedPanel.xaml
    /// </summary>
    public partial class FeedPanel : UserControl
    {
        private AppState _appState;
        public RssFeed? SelectedToRemove;
        private Label? selectedLabel;

        public FeedPanel()
        {
            InitializeComponent();

            this._appState = AppState.GetInstance();

            this.FeedsTitleLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupTitleColor);
            this.FeedsTitleLabel.FontSize = this._appState.LocalThemeConfiguration.LookupTitleFontSize;
            this.FeedsTitleLabel.FontFamily = this._appState.LocalThemeConfiguration.LookupTitleFontFamily;

            this.AddButton.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupBackgroundColor);
            this.AddButton.FontSize = this._appState.LocalThemeConfiguration.LookupDescriptionFontSize;
            this.AddButton.FontFamily = this._appState.LocalThemeConfiguration.LookupDescriptionFontFamily;

            this.RemoveButton.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupBackgroundColor);
            this.RemoveButton.FontSize = this._appState.LocalThemeConfiguration.LookupDescriptionFontSize;
            this.RemoveButton.FontFamily = this._appState.LocalThemeConfiguration.LookupDescriptionFontFamily;

            this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupBackgroundColor);
        }

        public async Task<RssFeed?> LoadAddFeedFromUrl(String url)
        {
            RssReader rssReader = new();
            Feed? feedResult = await rssReader.Read(url);
            if (feedResult == null) return null;

            RssFeed feed = new(feedResult.Title, url, feedResult.ImageUrl);
            //AddFeed(feed);

            return feed;
        }

        public void LoadFeeds(FeedCollection? feeds)
        {
            this.FeedsPanel.Children.Clear();

            if (feeds == null) return;

            foreach(RssFeed rssFeed in feeds.Feeds) 
            {
                AddFeed(rssFeed);
            }
        }

        public void AddFeed(RssFeed feed)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            if (String.IsNullOrEmpty(feed.ImageUrl)) return;
            bitmap.UriSource = new Uri(feed.ImageUrl, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            StackPanel feedPanel = new();
            feedPanel.Orientation = Orientation.Horizontal;
            feedPanel.Margin = new Thickness(5, 5, 5, 5);

            Label nameLabel = new();
            nameLabel.Content = feed.Name;
            nameLabel.VerticalAlignment = VerticalAlignment.Center;
            nameLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupDescriptionColor);
            nameLabel.FontFamily = this._appState.LocalThemeConfiguration.LookupDescriptionFontFamily;
            nameLabel.FontSize = this._appState.LocalThemeConfiguration.LookupDescriptionFontSize;

            Image urlImage = new();
            urlImage.Source = bitmap;

            urlImage.Width = 64;
            urlImage.Height = 64;

            feedPanel.Children.Add(urlImage);
            feedPanel.Children.Add(nameLabel);

            feedPanel.MouseEnter += (object sender, MouseEventArgs e) =>
            {
                feedPanel.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.NavigatorBackgroundColor);
            };

            feedPanel.MouseLeave += (object sender, MouseEventArgs e) =>
            {
                feedPanel.Background = null;
            };

            feedPanel.MouseUp += (object sender, MouseButtonEventArgs e) =>
            {
                if (this.SelectedToRemove != null)
                {
                    selectedLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupDescriptionColor);
                }
                this.SelectedToRemove = feed;
                this.selectedLabel = nameLabel;
                nameLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.NavigatorDefaultColor);
            };

            this.FeedsPanel.Children.Add(feedPanel);
        }
    }
}
