using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    interface ISitemapBackgroundTester
    {
        void Perform(IEnumerable<string> sitemapURLs, int sitemapTestId);
    }
}