using System.Linq;
using URLPerformanceTester.Models.Concrete;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public  class SitemapURLExtractorTests
    {
        [Fact]
        public void ExtractURLsTest()
        {
            //arrange
            var url = "https://google.com/sitemap.xml";
            var extracter = new SitemapUrlExtractor();
            //act
            var result = extracter.TryExtract(url).ToList();
            //assert
            Assert.True(result.Count!=0);
        }

    }
}
