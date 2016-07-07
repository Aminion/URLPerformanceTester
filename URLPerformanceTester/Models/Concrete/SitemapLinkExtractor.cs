using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapLinkExtractor : ISitemapLinksExtractor
    {
        public IEnumerable<string> Extract(XDocument sitemapDocument) => sitemapDocument.Descendants("loc").Select(e => e.Value);
    }
}