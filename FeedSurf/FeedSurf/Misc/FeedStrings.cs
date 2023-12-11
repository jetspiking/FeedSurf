using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedSurf.Misc
{
    public static class FeedStrings
    {
        public static readonly String ApplicationName = "FeedSurf";

        public static readonly String ApplicationDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly String ApplicationDirectoryThemes = ApplicationDirectory;
        public static readonly String ApplicationDirectoryFeeds = ApplicationDirectory;

        public static readonly String FileDefaultTheme = "Default.json";
        public static readonly String FileUser = "User.json";

        public static readonly String FileFeedsAll = "All.json";
        public static readonly String FileFeedsRecent = "Recent.json";

        public static readonly String FileDefaultImage = "OSQDark.png";

        public static readonly String InvalidThemeFile = "Theme file is invalid, fallback to default theme!";

        public static readonly Int32 RecentCount = 5;
    }
}
