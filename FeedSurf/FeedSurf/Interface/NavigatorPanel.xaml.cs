using CodeHollow.FeedReader;
using CodeHollow.FeedReader.Feeds;
using FeedSurf.Core;
using FeedSurf.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
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
using Path = System.IO.Path;

namespace FeedSurf.Interface
{
    /// <summary>
    /// Interaction logic for NavigatorPanel.xaml
    /// </summary>
    public partial class NavigatorPanel : UserControl
    {
        private AppState _appState;
        private ReaderPanel _readerPanel;
        private Window _window;
        private FeedCollection? _cachedSortedFeeds = null;
        private CancellationTokenSource _searchCancelToken = new CancellationTokenSource();
        public Boolean ForceClose = false;

        public NavigatorPanel()
        {
            InitializeComponent();

            _appState = AppState.GetInstance();
            _appState.NavigatorPanel = this;

            _appState._navigatorSelectColorBrush = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorSelectColor);
            _appState._navigatorDeselectColorBrush = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            _appState._navigatorDefaultColorBrush = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDefaultColor);

            this.UsernameLabel.Content = _appState.LocalUserConfiguration.YourText;

            this.Background = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorBackgroundColor);

            this.UsernameLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDefaultColor);
            this.TodayLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            this.FeaturedLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);

            this.FeedsLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDefaultColor);

            this.AllLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            this.RecentLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            this.FavoritesLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            this.DiscoverLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            this.SetupLabel.Foreground = new SolidColorBrush(_appState.LocalThemeConfiguration.NavigatorDeselectColor);
            //this.AddLabel.Foreground = new SolidColorBrush(appState.LocalThemeConfiguration.NavigatorDeselectColor);
            //this.SettingsLabel.Foreground = new SolidColorBrush(appState.LocalThemeConfiguration.NavigatorDeselectColor);

            this.UsernameLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorTitleFontFamily;
            this.UsernameLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorTitleFontSize;
            this.UsernameLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorTitleFontWeight;

            this.TodayLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.TodayLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.TodayLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.FeaturedLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.FeaturedLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.FeaturedLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.FeedsLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorTitleFontFamily;
            this.FeedsLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorTitleFontSize;
            this.FeedsLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorTitleFontWeight;

            this.AllLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.AllLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.AllLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.RecentLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.RecentLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.RecentLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.FavoritesLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.FavoritesLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.FavoritesLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.DiscoverLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.DiscoverLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.DiscoverLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            this.SetupLabel.FontFamily = _appState.LocalThemeConfiguration.NavigatorMenuFontFamily;
            this.SetupLabel.FontSize = _appState.LocalThemeConfiguration.NavigatorMenuFontSize;
            this.SetupLabel.FontWeight = _appState.LocalThemeConfiguration.NavigatorMenuFontWeight;

            if (String.IsNullOrEmpty(_appState.LocalUserConfiguration.YourText)) this.UsernameLabel.Visibility = Visibility.Collapsed;
            if (String.IsNullOrEmpty(_appState.LocalUserConfiguration.YourImage)) this.PanelImage.Visibility = Visibility.Collapsed;
            else
            {
                String imageUrl = Path.Combine(FeedStrings.ApplicationDirectory, _appState.LocalUserConfiguration.YourImage);

                if (!File.Exists(imageUrl)) this.PanelImage.Visibility = Visibility.Collapsed;
                else
                {
                    this.PanelImage.Source = new BitmapImage(new Uri(imageUrl));
                }
            }

            this.AllLabel.MouseDown += (object sender, MouseButtonEventArgs e) =>
            {
                SelectAllLabel();
            };

            this.RecentLabel.MouseDown += (object sender, MouseButtonEventArgs e) =>
            {
                SelectRecentLabel();
            };

            this.SetupLabel.MouseEnter += (object sender, MouseEventArgs e) =>
            {
                HoverSettingsLabel(true);
            };

            this.SetupLabel.MouseLeave += (object sender, MouseEventArgs e) =>
            {
                HoverSettingsLabel(false);
            };

            this.SetupLabel.MouseDown += (object sender, MouseButtonEventArgs e) =>
            {
                SelectSettingsLabel();
            };

            this._readerPanel = new ReaderPanel();

            this._window = new();
            this._window.Width = 800;
            this._window.Height = 600;
            this._window.Content = this._readerPanel;
            this._window.Closing += (object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                if (this.ForceClose) return;
                e.Cancel = true;
                this._readerPanel.ClearContent();
                this._window.Hide();
            };
        }

        public async void SelectAllLabel()
        {
            MainWindow.MainWindowInstance.SettingsPanel.Visibility = Visibility.Collapsed;
            MainWindow.MainWindowInstance.LookupPanel.Visibility = Visibility.Visible;

            this.AllLabel.Foreground = _appState._navigatorSelectColorBrush;
            this.RecentLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.FavoritesLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.DiscoverLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.SetupLabel.Foreground = _appState._navigatorDeselectColorBrush;

            await this._appState.ReadAllFeeds();
            await IndexFeeds(this._appState.FeedCollectionAll, true);
        }

        public async void SelectRecentLabel()
        {
            MainWindow.MainWindowInstance.SettingsPanel.Visibility = Visibility.Collapsed;
            MainWindow.MainWindowInstance.LookupPanel.Visibility = Visibility.Visible;

            this.RecentLabel.Foreground = _appState._navigatorSelectColorBrush;
            this.AllLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.FavoritesLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.DiscoverLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.SetupLabel.Foreground = _appState._navigatorDeselectColorBrush;

            await this._appState.ReadRecentFeeds();
            await IndexFeeds(this._appState.FeedCollectionRecent, false);
        }

        public async void SelectSettingsLabel() 
        {
            this.FeedsPanel.Children.Clear();
            this._appState.LookupPanel.ClearItems();

            this.DiscoverLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.FavoritesLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.AllLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.RecentLabel.Foreground = _appState._navigatorDeselectColorBrush;
            this.SetupLabel.Foreground = _appState._navigatorSelectColorBrush;

            MainWindow.MainWindowInstance.SettingsPanel.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.LookupPanel.Visibility = Visibility.Collapsed;
        }

        public async void HoverSettingsLabel(Boolean selected)
        {
            this.SetupLabel.Foreground = selected ? _appState._navigatorSelectColorBrush : _appState._navigatorDeselectColorBrush;
        }

        private async Task IndexFeeds(FeedCollection? feedCollection, Boolean orderByName)
        {
            this.FeedsPanel.Children.Clear();
            this._appState.LookupPanel.ClearItems();
            if (feedCollection == null) return;

            if (orderByName && _cachedSortedFeeds != feedCollection)
            {
                feedCollection.Feeds = feedCollection.Feeds.OrderBy(rssFeed => rssFeed.Name).ToArray();
                _cachedSortedFeeds = feedCollection;
            }

            foreach (RssFeed feed in feedCollection.Feeds)
            {
                FeedSelectionItem item = new FeedSelectionItem(feed);
                this.FeedsPanel.Children.Add(item);

                item.MouseDown += (object sender, MouseButtonEventArgs e) =>
                {
                    foreach (FeedSelectionItem otherItem in this.FeedsPanel.Children)
                    {
                        otherItem.DeselectItem();
                    }
                    item.SelectItem();

                    RetrieveData(feed);
                    ValidateAddRecent(feed);
                };
            }
        }

        private async void ValidateAddRecent(RssFeed feed)
        {
            await Task.Run(() =>
            {
                FeedCollection? feedsCollection = this._appState.FeedCollectionRecent;
                if (feedsCollection == null)
                {
                    feedsCollection = new FeedCollection();
                }
                if (feedsCollection.Feeds == null) feedsCollection.Feeds = new List<RssFeed>().ToArray();
                List<RssFeed> feedsList = feedsCollection.Feeds.ToList();
                IEnumerable<RssFeed> existingResults = feedsList.Where(f => f.Name == feed.Name);
                if (existingResults.Count() != 0) return;
                feedsList.Insert(0, feed);
                while (feedsList.Count()>FeedStrings.RecentCount)
                    feedsList.RemoveAt(feedsList.Count()-1);
                feedsCollection.Feeds = feedsList.ToArray();
                StateSerializer.ToDiskFeedCollectionRecent(feedsCollection);
            });
        }

        public async void RetrieveData(RssFeed feed)
        {
            this._searchCancelToken.Cancel();
            this._searchCancelToken = new();
            CancellationToken cancelToken = this._searchCancelToken.Token;

            this._appState.LookupPanel.ClearItems();
            RssReader rssReader = new();
            Feed? feedResult = await rssReader.Read(feed.Url);
            if (feedResult == null) return;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            if (String.IsNullOrEmpty(feed.ImageUrl)) return;
            bitmap.UriSource = new Uri(feed.ImageUrl, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            List<BaseFeedItem> baseFeedItems = feedResult.SpecificFeed.Items.ToList();

            XDocument xDocument = XDocument.Parse(feedResult.OriginalDocument);
            XNamespace xNamespace = xDocument.Root.GetDefaultNamespace();

            foreach (FeedItem feedItem in feedResult.Items)
            {
                PostItem postItem = new PostItem(feedItem, baseFeedItems[feedResult.Items.IndexOf(feedItem)], xNamespace, bitmap);

                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    if (cancelToken.IsCancellationRequested) return;
                    this._appState.LookupPanel.InsertItem(postItem);
                }, DispatcherPriority.Background);

                postItem.MouseUp += (object sender, MouseButtonEventArgs e) =>
                {
                    this._readerPanel.LoadContent(feedItem, postItem.FeedImage, postItem.ExtraContentUrl);
                    this._window.Show();
                    this._window.Topmost = true;
                    this._window.WindowState = WindowState.Normal;
                };
            }
        }
    }
}
