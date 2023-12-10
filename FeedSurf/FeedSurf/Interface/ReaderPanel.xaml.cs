using CodeHollow.FeedReader;
using CodeHollow.FeedReader.Feeds;
using CodeHollow.FeedReader.Feeds.Itunes;
using FeedSurf.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace FeedSurf.Interface
{
    /// <summary>
    /// Interaction logic for ReaderPanel.xaml
    /// </summary>
    public partial class ReaderPanel : UserControl
    {
        private AppState _appState { get; set; }
        private String _extraContentUrl { get; set; }
        public ReaderPanel()
        {
            InitializeComponent();

            AppState appState = AppState.GetInstance();
            appState.ReaderPanel = this;
            this._appState = appState;
            this.Browser.EnsureCoreWebView2Async();
            this.ExtraContentBrowser.EnsureCoreWebView2Async();
        }

        public void ClearContent()
        {
            this.Browser.NavigateToString(String.Empty);
            this.ExtraContentBrowser.NavigateToString(String.Empty);
        }

        public async void LoadContent(FeedItem feedItem, Image feedImage, String extraContentUrl)
        {
            this._extraContentUrl = extraContentUrl;
            await this.Browser.EnsureCoreWebView2Async();
            if (!String.IsNullOrEmpty(feedItem.Content))
                this.Browser.NavigateToString(feedItem.Content);
            else if (!String.IsNullOrEmpty(feedItem.Description)) this.Browser.NavigateToString(feedItem.Description);

            this.Background = new SolidColorBrush(this._appState.LocalThemeConfiguration.ReaderBackgroundColor);

            this.Icon.Source = feedImage.Source;

            this.TitleLabel.Text = feedItem.Title;
            this.TitleLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.ReaderTitleColor);
            this.TitleLabel.FontFamily = this._appState.LocalThemeConfiguration.ReaderTitleFontFamily;
            this.TitleLabel.FontSize = this._appState.LocalThemeConfiguration.ReaderTitleFontSize;
            this.TitleLabel.FontWeight = this._appState.LocalThemeConfiguration.ReaderTitleFontWeight;

            this.AuthorLabel.Text = feedItem.Author;
            this.AuthorLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.ReaderStoryColor);
            this.AuthorLabel.FontFamily = this._appState.LocalThemeConfiguration.ReaderStoryFontFamily;
            this.AuthorLabel.FontSize = this._appState.LocalThemeConfiguration.ReaderStoryFontSize;
            this.AuthorLabel.FontWeight = this._appState.LocalThemeConfiguration.ReaderStoryFontWeight;

            this.DateLabel.Text = feedItem.PublishingDate.ToString();
            this.DateLabel.Foreground = new SolidColorBrush(this._appState.LocalThemeConfiguration.ReaderDateTimeColor);
            this.DateLabel.FontFamily = this._appState.LocalThemeConfiguration.ReaderDateTimeFontFamily;
            this.DateLabel.FontSize = this._appState.LocalThemeConfiguration.ReaderDateTimeFontSize;
            this.DateLabel.FontWeight = this._appState.LocalThemeConfiguration.ReaderDateTimeFontWeight;

            this.ExtraContentDefinition.Width = new GridLength(1, GridUnitType.Star);

            if (String.IsNullOrEmpty(extraContentUrl)) 
            {
                this.ExtraContentDefinition.Width = new GridLength(0);
                return;
            }

            await this.ExtraContentBrowser.EnsureCoreWebView2Async();
            this.ExtraContentBrowser.Source = new Uri(this._extraContentUrl);
        }
    }
}
