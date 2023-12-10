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
        public static readonly String ThemesDirectory = "Themes";
        public static readonly String FeedsDirectory = "Feeds";
        public static readonly String PostsDirectory = "Posts";

        public static readonly String ApplicationDirectoryThemes = Path.Combine(ApplicationDirectory, ThemesDirectory);
        public static readonly String ApplicationDirectoryFeeds = Path.Combine(ApplicationDirectory, FeedsDirectory);
        public static readonly String ApplicationDirectoryPosts = Path.Combine(ApplicationDirectory, PostsDirectory);

        public static readonly String FileDefaultTheme = "Default.json";
        public static readonly String FileUser = "User.json";

        public static readonly String FileFeedsAll = "All.json";
        public static readonly String FileFeedsRecent = "Recent.json";

        public static readonly String FileDefaultImage = "OSQDark.png";
        public static readonly Int32 RecentCount = 5;
    }
}
