using System;
using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Abstract;


namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapBuiler : ISitemapBuilder
    {
        private readonly IHtmlLinksExtractor _linksExtractor;
        public SitemapBuiler(IHtmlLinksExtractor linksExtractor)
        {
            _linksExtractor = linksExtractor;
        }
        public IEnumerable<string> BuildSitemap(string url)
        {
            var urlsToTest = new List<string>() { url };
            var result = new HashSet<string>() { url };
            while (urlsToTest.Any())
            {
                var current = urlsToTest.LastOrDefault();
                urlsToTest.Remove(current);
                var urls = _linksExtractor.Extract(current);
                if (urls == null) continue;
                var filteredUrls = urls
                    .Where(u => !isNavigationLink(u) && isInnerUrl(u, url))
                    .Select(u => ExtendUrlIfLocal(u, url))
                    .Where(u => !result.Contains(u));
                urlsToTest.AddRange(filteredUrls);
                foreach (var u in filteredUrls) result.Add(u);
            }
            return result;
        }
        private string ExtendUrlIfLocal(string url, string baseUrl)
        {
            if (url.StartsWith("http://") || url.StartsWith("htts://")) return url;
            return new Uri(new Uri(baseUrl), url).AbsoluteUri;
        }
        private bool isInnerUrl(string url, string adress) =>
             url.StartsWith(adress) || url.StartsWith("/");
        private bool isNavigationLink(string url) => url.Contains("#");
    }
}