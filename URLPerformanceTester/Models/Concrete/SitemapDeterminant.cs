using System.Collections.Generic;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapDeterminant : ISitemapDeterminant
    {
        private readonly ISitemapReader _sitemapReader;
        private readonly ISitemapBuilder _sitemapBuilder;
        public SitemapDeterminant(ISitemapReader sitemapReader, ISitemapBuilder sitemapBuilder)
        {
            _sitemapReader = sitemapReader;
            _sitemapBuilder = sitemapBuilder;
        }

        public IEnumerable<string> DeterminateSitemap(string url)
        {
            var sitemapUrl = url.TrimEnd('/') + "/sitemap.xml";
            IEnumerable<string> urls = null;
            if (!_sitemapReader.TryReadSitemap(sitemapUrl, out urls)) return urls;
            else return _sitemapBuilder.BuildSitemap(url);
        }
    }
}