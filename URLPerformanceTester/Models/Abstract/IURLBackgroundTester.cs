using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapBackgroundTester
    {
        void Perform(IEnumerable<string> sitemapUrLs, int sitemapTestId);
    }
}