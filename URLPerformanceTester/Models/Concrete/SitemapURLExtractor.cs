using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapUrlExtractor : ISitemapExtractor
    {
        private bool IsSitemap(XDocument document) => document.Root?.Name.LocalName == "urlset";
        private bool IsSitemapIndex(XDocument document) => document.Root?.Name.LocalName == "sitemapindex";

        private IEnumerable<string> ExtractUrLs(XDocument sitemap)
            => sitemap.Descendants().Where(e => e.Name.LocalName == "loc").Select(e => e.Value);

        public IEnumerable<string> TryExtract(string sitemapUrl)
        {
            var doc = XDocument.Load(sitemapUrl);
            var urls = ExtractUrLs(doc);
            if (IsSitemap(doc))
            {
                return urls;
            }
            if (IsSitemapIndex(doc))
            {
                var result = new List<string>();
                foreach (var url in urls)
                {
                    var append = TryExtract(url);
                    if (append != null) result.AddRange(append);
                }
                return result;
            }
            return null;
        }
    }
}