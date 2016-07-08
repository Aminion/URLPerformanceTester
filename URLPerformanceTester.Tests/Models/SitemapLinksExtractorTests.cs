using System.Linq;
using URLPerformanceTester.Models.Concrete;
using System.Xml.Linq;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public  class SitemapLinksExtractorTests
    {
        [Fact]
        public void ExtractLinks()
        {
            //arrange
            var doc = XDocument.Parse("<sitemapindex><sitemap><loc>one</loc></sitemap><sitemap><loc>two</loc></sitemap></sitemapindex>");
            var extracter = new SitemapLinkExtractor();
            //act
            var result = extracter.Extract(doc).ToList();
            //assert
            Assert.Equal("one", result[0]);
            Assert.Equal("two", result[1]);
        }

    }
}
