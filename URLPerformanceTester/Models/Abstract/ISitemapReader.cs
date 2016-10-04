using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapReader
    {
        bool TryReadSitemap(string sitemapUrl, out IEnumerable<string> sitemapUrls);
    }
}
