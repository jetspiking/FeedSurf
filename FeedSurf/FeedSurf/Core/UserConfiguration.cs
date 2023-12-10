using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedSurf.Core
{
    public class UserConfiguration
    {
        public String YourText { get; set; }
        public String YourImage { get; set; }
        public String ThemeActive { get; set; }
        public UserConfiguration(String yourText, String yourImage, String themeActive)
        {
            YourText = yourText;
            YourImage = yourImage;
            ThemeActive = themeActive;
        }
    }
}
