using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapReader : ISitemapReader
    {
        private string RootName(XDocument document) => document.Root?.Name.LocalName;
        private IEnumerable<string> ExtractUrLs(XDocument sitemap)
            => sitemap.Descendants().Where(e => e.Name.LocalName == "loc").Select(e => e.Value);

        public bool TryReadSitemap(string sitemapUrl, out IEnumerable<string> sitemapUrls)
        {
            try
            {
                var doc = XDocument.Load(sitemapUrl);
                var rootname = RootName(doc);
                if (rootname == "urlset")
                {
                    sitemapUrls = ExtractUrLs(doc);
                    return true;
                }
                else if (rootname == "sitemapindex")
                {
                    var result = new List<string>();
                    var doc_t = ExtractUrLs(doc);
                    foreach (var url in doc_t)
                    {
                        var ext = ExtractUrLs(XDocument.Load(url));
                        result.AddRange(ext);
                    }
                    sitemapUrls = result;
                    return true;
                }
            }
            catch (WebException ex)
            {
                sitemapUrls = null;
                return false;
            }
            catch (XmlException ex)
            {
                sitemapUrls = null;
                return false;
            }
            sitemapUrls = null;
            return false;
        }
    }
}