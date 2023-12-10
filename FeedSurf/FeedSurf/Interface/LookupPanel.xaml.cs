using FeedSurf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LookupPanel.xaml
    /// </summary>
    public partial class LookupPanel : UserControl
    {
        public LookupPanel()
        {
            InitializeComponent();

            AppState appState = AppState.GetInstance();
            appState.LookupPanel = this;

            this.Background = new SolidColorBrush(appState.LocalThemeConfiguration.LookupBackgroundColor);
        }

        public void InsertItem(PostItem postItem)
        {
            this.FeedPanel.Children.Add(postItem);
        }

        public void ClearItems()
        {
            this.FeedPanel.Children.Clear();
        }
    }
}
