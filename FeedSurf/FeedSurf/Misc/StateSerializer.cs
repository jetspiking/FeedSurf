using FeedSurf.Core;
using System.IO;

namespace FeedSurf.Misc
{
    public static class StateSerializer
    {
        public static Boolean HasDiskThemeConfiguration(String themeName)
        {
            return File.Exists(Path.Combine(FeedStrings.ApplicationDirectoryThemes, themeName));
        }

        public static void ToDiskThemeConfiguration(ThemeConfiguration themeConfiguration, String themeName)
        {
            if (!Directory.Exists(FeedStrings.ApplicationDirectoryThemes))
                Directory.CreateDirectory(FeedStrings.ApplicationDirectoryThemes);
            Misc.JsonManager.SerializeToFile<ThemeConfiguration>(themeConfiguration, Path.Combine(FeedStrings.ApplicationDirectoryThemes, themeName));
        }
        public static ThemeConfiguration? FromDiskThemeConfiguration(String themeName)
        {
            return Misc.JsonManager.DeserializeFromFile<ThemeConfiguration>(Path.Combine(FeedStrings.ApplicationDirectoryThemes, themeName));
        }

        public static void ToDiskUserConfiguration(UserConfiguration userConfiguration)
        {
            Misc.JsonManager.SerializeToFile<UserConfiguration>(userConfiguration, Path.Combine(FeedStrings.ApplicationDirectory, FeedStrings.FileUser));
        }
        public static UserConfiguration? FromDiskUserConfiguration()
        {
            return Misc.JsonManager.DeserializeFromFile<UserConfiguration>(Path.Combine(FeedStrings.ApplicationDirectory, FeedStrings.FileUser));
        }

        public static void ToDiskFeedCollectionAll(FeedCollection feedCollection)
        {
            Misc.JsonManager.SerializeToFile<FeedCollection>(feedCollection, Path.Combine(FeedStrings.ApplicationDirectoryFeeds, FeedStrings.FileFeedsAll));
        }

        public static FeedCollection? FromDiskFeedCollectionAll()
        {
            return Misc.JsonManager.DeserializeFromFile<FeedCollection>(Path.Combine(FeedStrings.ApplicationDirectoryFeeds, FeedStrings.FileFeedsAll));
        }

        public static void ToDiskFeedCollectionRecent(FeedCollection feedCollection)
        {
            Misc.JsonManager.SerializeToFile<FeedCollection>(feedCollection, Path.Combine(FeedStrings.ApplicationDirectoryFeeds, FeedStrings.FileFeedsRecent));
        }

        public static FeedCollection? FromDiskFeedCollectionRecent()
        {
            return Misc.JsonManager.DeserializeFromFile<FeedCollection>(Path.Combine(FeedStrings.ApplicationDirectoryFeeds, FeedStrings.FileFeedsRecent));
        }

    }
}
