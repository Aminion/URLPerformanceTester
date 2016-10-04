using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapDeterminant
    {
        IEnumerable<string> DeterminateSitemap(string sitemapUrl);
    }
}
