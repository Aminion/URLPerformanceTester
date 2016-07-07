using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapDocumentReader : ISitemapDocumentReader
    {
        private const string _sitemapFileName = "sitemap.xml";
        public XDocument GetSitemapDocument(string url) => XDocument.Load(url + _sitemapFileName);
    }
}
