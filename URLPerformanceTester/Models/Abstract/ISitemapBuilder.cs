using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public  interface ISitemapBuilder
    {
        IEnumerable<string> BuildSitemap(string sitemapUrl);
    }
}
