using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using FeedSurf.Misc;

namespace FeedSurf.Core
{
    public static class ThemeMocker
    {
        public static ThemeConfiguration GetFallbackTheme()
        {
            FontFamily fontFamily = new FontFamily("Segoe UI");
            ThemeConfiguration themeConfiguration = new(25, 15, 18,
                                                        21, 17, 17,
                                                        15, 15, 15,
                                                        Colors.White, Color.FromRgb(255, 106, 0), Colors.DarkGray, Color.FromRgb(15,15,15),
                                                        Colors.White, Colors.DarkGray, Colors.White, Color.FromRgb(20,20,20),
                                                        Colors.White, Colors.White, Colors.White, Color.FromRgb(20, 20, 20),
                                                        FontWeights.Bold, FontWeights.Normal, FontWeights.Normal,
                                                        FontWeights.Normal, FontWeights.Light, FontWeights.Light,
                                                        FontWeights.Bold, FontWeights.Normal, FontWeights.Normal,
                                                        fontFamily, fontFamily, fontFamily,
                                                        fontFamily, fontFamily, fontFamily,
                                                        fontFamily, fontFamily, fontFamily);
            return themeConfiguration;
        }
    }
}
