using CodeHollow.FeedReader.Feeds;
using CodeHollow.FeedReader;
using FeedSurf.Core;
using FeedSurf.Misc;
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
using System.Windows.Threading;
using System.Xml.Linq;
using System.Windows.Media.Animation;

namespace FeedSurf.Interface
{
    /// <summary>
    /// Interaction logic for SettingsPanel.xaml
    /// </summary>
    public partial class SettingsPanel : UserControl
    {
        private AppState _appState;

        public SettingsPanel()
        {
            InitializeComponent();

            this._appState = AppState.GetInstance();

            this.AllPanel.FeedsTitleLabel.Content += $" {FeedStrings.FileFeedsAll}";

            this.AllPanel.AddButton.Click += (object sender, RoutedEventArgs e) =>
            {
                LoadFeedAll();
            };

            this.AllPanel.RemoveButton.Click += (object sender, RoutedEventArgs e) =>
            {
                RemoveFeedAll();
            };

            LoadFeedLists();
        }

        public async void LoadFeedAll()
        {
            if (this._appState.FeedCollectionAll == null) this._appState.FeedCollectionAll = new FeedCollection();

            RssFeed? feed = await this.AllPanel.LoadAddFeedFromUrl(this.AllPanel.UrlBox.Text);
            if (feed != null) 
            {
                List<RssFeed> rssFeed = this._appState.FeedCollectionAll.Feeds.ToList<RssFeed>();
                if (rssFeed.Any(f => f.Url == this.AllPanel.UrlBox.Text)) return;
                rssFeed.Add(feed);
                this.AllPanel.AddFeed(feed);
                this._appState.FeedCollectionAll.Feeds = rssFeed.ToArray();
                this._appState.SaveAllFeeds();
                this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.NavigatorBackgroundColor);
            }
        }

        public void RemoveFeedAll()
        {
            if (this.AllPanel.SelectedToRemove == null) return;

            List<RssFeed> rssFeed = this._appState.FeedCollectionAll.Feeds.ToList<RssFeed>();
            rssFeed.RemoveAll(f => f.Url == this.AllPanel.SelectedToRemove.Url);
            this._appState.FeedCollectionAll.Feeds = rssFeed.ToArray();
            this._appState.SaveAllFeeds();
            this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.NavigatorBackgroundColor);

            LoadFeedLists();
        }

        public async void LoadFeedLists()
        {
            await this._appState.ReadAllFeeds();
            this.AllPanel.LoadFeeds(this._appState.FeedCollectionAll);
        }
    }
}
