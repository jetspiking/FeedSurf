using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace FeedSurf.Core
{
    public class ThemeConfiguration
    {
        public Int32 NavigatorTitleFontSize { get; set; }
        public Int32 NavigatorFeedFontSize { get; set; }
        public Int32 NavigatorMenuFontSize { get; set; }

        public Int32 LookupTitleFontSize { get; set; }
        public Int32 LookupDescriptionFontSize { get; set; }
        public Int32 LookupDateTimeFontSize { get; set; }

        public Int32 ReaderDateTimeFontSize { get; set; }
        public Int32 ReaderTitleFontSize { get; set; }
        public Int32 ReaderStoryFontSize { get; set; }

        public Color NavigatorDefaultColor { get; set; }
        public Color NavigatorSelectColor { get; set; }
        public Color NavigatorDeselectColor { get; set; }
        public Color NavigatorBackgroundColor { get; set; }

        public Color LookupTitleColor { get; set; }
        public Color LookupDescriptionColor { get; set; }
        public Color LookupDateTimeColor { get; set; }
        public Color LookupBackgroundColor { get; set; }

        public Color ReaderTitleColor { get; set; }
        public Color ReaderStoryColor { get; set; }
        public Color ReaderDateTimeColor { get; set; }
        public Color ReaderBackgroundColor { get; set; }

        public FontWeight NavigatorTitleFontWeight { get; set; }
        public FontWeight NavigatorFeedFontWeight { get; set; }
        public FontWeight NavigatorMenuFontWeight { get; set; }

        public FontWeight LookupTitleFontWeight { get; set; }
        public FontWeight LookupDescriptionFontWeight { get; set; }
        public FontWeight LookupDateTimeFontWeight { get; set; }

        public FontWeight ReaderTitleFontWeight { get; set; }
        public FontWeight ReaderStoryFontWeight { get; set; }
        public FontWeight ReaderDateTimeFontWeight { get; set; }

        public FontFamily NavigatorTitleFontFamily { get; set; }
        public FontFamily NavigatorFeedFontFamily { get; set; }
        public FontFamily NavigatorMenuFontFamily { get; set; }

        public FontFamily LookupTitleFontFamily { get; set; }
        public FontFamily LookupDescriptionFontFamily { get; set; }
        public FontFamily LookupDateTimeFontFamily { get; set; }

        public FontFamily ReaderTitleFontFamily { get; set; }
        public FontFamily ReaderStoryFontFamily { get; set; }
        public FontFamily ReaderDateTimeFontFamily { get; set; }

        public ThemeConfiguration(Int32 navigatorTitleFontSize,
                                  Int32 navigatorFeedFontSize,
                                  Int32 navigatorMenuFontSize,
                                  Int32 lookupTitleFontSize,
                                  Int32 lookupDescriptionFontSize,
                                  Int32 lookupDateTimeFontSize,
                                  Int32 readerDateTimeFontSize,
                                  Int32 readerTitleFontSize,
                                  Int32 readerStoryFontSize,
                                  Color navigatorDefaultColor,
                                  Color navigatorSelectColor,
                                  Color navigatorDeselectColor,
                                  Color navigatorBackgroundColor,
                                  Color lookupTitleColor,
                                  Color lookupDescriptionColor,
                                  Color lookupDateTimeColor,
                                  Color lookupBackgroundColor,
                                  Color readerTitleColor,
                                  Color readerStoryColor,
                                  Color readerDateTimeColor,
                                  Color readerBackgroundColor,
                                  FontWeight navigatorTitleFontWeight,
                                  FontWeight navigatorFeedFontWeight,
                                  FontWeight navigatorMenuFontWeight,
                                  FontWeight lookupTitleFontWeight,
                                  FontWeight lookupDescriptionFontWeight,
                                  FontWeight lookupDateTimeFontWeight,
                                  FontWeight readerTitleFontWeight,
                                  FontWeight readerStoryFontWeight,
                                  FontWeight readerDateTimeFontWeight,
                                  FontFamily navigatorTitleFontFamily,
                                  FontFamily navigatorFeedFontFamily,
                                  FontFamily navigatorMenuFontFamily,
                                  FontFamily lookupTitleFontFamily,
                                  FontFamily lookupDescriptionFontFamily,
                                  FontFamily lookupDateTimeFontFamily,
                                  FontFamily readerTitleFontFamily,
                                  FontFamily readerStoryFontFamily,
                                  FontFamily readerDateTimeFontFamily)
        {
            NavigatorTitleFontSize = navigatorTitleFontSize;
            NavigatorFeedFontSize = navigatorFeedFontSize;
            NavigatorMenuFontSize = navigatorMenuFontSize;
            LookupTitleFontSize = lookupTitleFontSize;
            LookupDescriptionFontSize = lookupDescriptionFontSize;
            LookupDateTimeFontSize = lookupDateTimeFontSize;
            ReaderDateTimeFontSize = readerDateTimeFontSize;
            ReaderTitleFontSize = readerTitleFontSize;
            ReaderStoryFontSize = readerStoryFontSize;
            NavigatorDefaultColor = navigatorDefaultColor;
            NavigatorSelectColor = navigatorSelectColor;
            NavigatorDeselectColor = navigatorDeselectColor;
            NavigatorBackgroundColor = navigatorBackgroundColor;
            LookupTitleColor = lookupTitleColor;
            LookupDescriptionColor = lookupDescriptionColor;
            LookupDateTimeColor = lookupDateTimeColor;
            LookupBackgroundColor = lookupBackgroundColor;
            ReaderTitleColor = readerTitleColor;
            ReaderStoryColor = readerStoryColor;
            ReaderDateTimeColor = readerDateTimeColor;
            ReaderBackgroundColor = readerBackgroundColor;
            NavigatorTitleFontWeight = navigatorTitleFontWeight;
            NavigatorFeedFontWeight = navigatorFeedFontWeight;
            NavigatorMenuFontWeight = navigatorMenuFontWeight;
            LookupTitleFontWeight = lookupTitleFontWeight;
            LookupDescriptionFontWeight = lookupDescriptionFontWeight;
            LookupDateTimeFontWeight = lookupDateTimeFontWeight;
            ReaderTitleFontWeight = readerTitleFontWeight;
            ReaderStoryFontWeight = readerStoryFontWeight;
            ReaderDateTimeFontWeight = readerDateTimeFontWeight;
            NavigatorTitleFontFamily = navigatorTitleFontFamily;
            NavigatorFeedFontFamily = navigatorFeedFontFamily;
            NavigatorMenuFontFamily = navigatorMenuFontFamily;
            LookupTitleFontFamily = lookupTitleFontFamily;
            LookupDescriptionFontFamily = lookupDescriptionFontFamily;
            LookupDateTimeFontFamily = lookupDateTimeFontFamily;
            ReaderTitleFontFamily = readerTitleFontFamily;
            ReaderStoryFontFamily = readerStoryFontFamily;
            ReaderDateTimeFontFamily = readerDateTimeFontFamily;
        }
    }
}
