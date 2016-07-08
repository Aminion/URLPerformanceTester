using System.Collections.Generic;
using System.Xml.Linq;

namespace URLPerformanceTester.Models.Abstract
{
    interface ISitemapLinksExtractor
    {
        IEnumerable<string> Extract(XDocument sitemapDocument);
    }
}
