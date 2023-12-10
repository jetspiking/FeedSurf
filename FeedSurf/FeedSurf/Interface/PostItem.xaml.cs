using CodeHollow.FeedReader;
using CodeHollow.FeedReader.Feeds;
using CodeHollow.FeedReader.Feeds.Itunes;
using FeedSurf.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace FeedSurf.Interface
{
    /// <summary>
    /// Interaction logic for PostItem.xaml
    /// </summary>
    public partial class PostItem : UserControl
    {
        private AppState _appState;
        public String? ExtraContentUrl;

        public PostItem(FeedItem feedItem, BaseFeedItem specificFeedItem, XNamespace xNamespace, BitmapImage displayImage)
        {
            InitializeComponent();

            this._appState = AppState.GetInstance();

            this.DateLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupDateTimeColor);
            this.DateLabel.FontFamily = this._appState.LocalThemeConfiguration.LookupDateTimeFontFamily;
            this.DateLabel.FontSize = this._appState.LocalThemeConfiguration.LookupDateTimeFontSize;
            this.DateLabel.FontWeight = this._appState.LocalThemeConfiguration.LookupDateTimeFontWeight;

            this.DescriptionLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupDescriptionColor);
            this.DescriptionLabel.FontFamily = this._appState.LocalThemeConfiguration.LookupDescriptionFontFamily;
            this.DescriptionLabel.FontSize = this._appState.LocalThemeConfiguration.LookupDescriptionFontSize;
            this.DescriptionLabel.FontWeight = this._appState.LocalThemeConfiguration.LookupDescriptionFontWeight;

            this.TitleLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.LookupTitleColor);
            this.TitleLabel.FontFamily = this._appState.LocalThemeConfiguration.LookupTitleFontFamily;
            this.TitleLabel.FontSize = this._appState.LocalThemeConfiguration.LookupTitleFontSize;
            this.TitleLabel.FontWeight = this._appState.LocalThemeConfiguration.LookupTitleFontWeight;

            this.DateLabel.Content = feedItem.PublishingDate.ToString();
            this.TitleLabel.Content = feedItem.Title;
            this.DescriptionLabel.Text = feedItem.Description;

            this.FeedImage.Source = displayImage;

            this.MouseEnter += (object sender, MouseEventArgs e) =>
            {
                this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.NavigatorBackgroundColor);
            };
            this.MouseLeave += (object sender, MouseEventArgs e) =>
            {
                this.Background = null;
            };

            this.ExtraContentUrl = String.Empty;

            try
            {
                if (specificFeedItem.Element.Descendants().Any(x => x.Name.LocalName == xNamespace + "content"))
                {
                    this.ExtraContentUrl = specificFeedItem.Element.Descendants().First(x => x.Name.LocalName == xNamespace + "content").Attribute("url").Value;
                }
                else if (specificFeedItem.Element.Descendants().Any(x => x.Name.LocalName == "enclosure"))
                {
                    this.ExtraContentUrl = specificFeedItem.Element.Descendants().First(x => x.Name.LocalName == "enclosure").Attribute("url").Value;
                }
            }
            catch (Exception e) { this.ExtraContentUrl = null; }
        }
    }
}
