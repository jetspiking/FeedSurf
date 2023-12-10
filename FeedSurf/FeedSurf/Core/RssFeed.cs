using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedSurf.Core
{
    public class RssFeed
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public String ImageUrl { get; set; }

        public RssFeed(String name, String url, String imageUrl)
        {
            Name = name;
            Url = url;
            ImageUrl = imageUrl;
        }
    }
}
