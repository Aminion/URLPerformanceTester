using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace URLPerformanceTester.Models.Abstract
{
    interface ISitemapLinksExtractor
    {
        IEnumerable<string> Extract(XDocument sitemapDocument);
    }
}
