using System.Collections.Generic;
using System.Xml.Linq;

namespace URLPerformanceTester.Models.Abstract
{
    interface ISitemapURLExtractor
    {
        IEnumerable<string> Extract(XDocument sitemapDocument);
    }
}
