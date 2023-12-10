using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedSurf.Core
{
    public class RssReader
    {
        public async Task<CodeHollow.FeedReader.Feed?> Read(String url)
        {
            if (String.IsNullOrEmpty(url)) return null;
            return await FeedReader.ReadAsync(url);
        }
    }
}
