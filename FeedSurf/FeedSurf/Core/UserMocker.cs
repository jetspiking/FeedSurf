using FeedSurf.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedSurf.Core
{
    public class UserMocker
    {
        public static UserConfiguration GetFallbackUser()
        {
            UserConfiguration userConfiguration = new UserConfiguration(FeedStrings.ApplicationName, FeedStrings.FileDefaultImage, FeedStrings.FileDefaultTheme);
            return userConfiguration;
        }
    }
}
