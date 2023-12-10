using FeedSurf.Interface;
using FeedSurf.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FeedSurf.Core
{
    public class AppState
    {
        private static AppState _appStateManager;

        public static AppState GetInstance()
        {
            if (_appStateManager == null)
                _appStateManager = new AppState();
            return _appStateManager;
        }

        private AppState()
        {
            InitUser();
            InitThemes();
        }

        public UserConfiguration LocalUserConfiguration { get; set; }
        public ThemeConfiguration LocalThemeConfiguration { get; set; }
        public FeedCollection? FeedCollectionAll { get; set; }
        public FeedCollection? FeedCollectionRecent { get; set; }
        public FeedCollection? FeedCollectionFavorites { get; set; }
        public FeedCollection? FeedCollectionDiscover { get; set; }
        public NavigatorPanel NavigatorPanel { get; set; }
        public LookupPanel LookupPanel { get; set; }
        public ReaderPanel ReaderPanel { get; set; }
        public SolidColorBrush _navigatorSelectColorBrush { get; set; }
        public SolidColorBrush _navigatorDeselectColorBrush { get; set; }
        public SolidColorBrush _navigatorDefaultColorBrush { get; set; }

        private void InitUser() 
        {
            UserConfiguration? userConfiguration = StateSerializer.FromDiskUserConfiguration();
            if (userConfiguration != null)
            {
                this.LocalUserConfiguration = userConfiguration;
                return;
            }

            this.LocalUserConfiguration = UserMocker.GetFallbackUser();
            StateSerializer.ToDiskUserConfiguration(this.LocalUserConfiguration);
        }

        private void InitThemes()
        {
            ThemeConfiguration? existingTheme = StateSerializer.FromDiskThemeConfiguration(LocalUserConfiguration.ThemeActive);
            if (existingTheme != null)
            {
                this.LocalThemeConfiguration = existingTheme;
                return;
            }

            this.LocalThemeConfiguration = ThemeMocker.GetFallbackTheme();
            StateSerializer.ToDiskThemeConfiguration(this.LocalThemeConfiguration, LocalUserConfiguration.ThemeActive);
        }

        public async Task ReadAllFeeds()
        {
            this.FeedCollectionAll = StateSerializer.FromDiskFeedCollectionAll();
        }

        public async void SaveAllFeeds()
        {
            StateSerializer.ToDiskFeedCollectionAll(this.FeedCollectionAll);
        }

        public async Task ReadRecentFeeds()
        {
            this.FeedCollectionRecent = StateSerializer.FromDiskFeedCollectionRecent();
        }

        public async void SaveRecentFeeds()
        {
            StateSerializer.ToDiskFeedCollectionRecent(this.FeedCollectionRecent);
        }
    }
}
