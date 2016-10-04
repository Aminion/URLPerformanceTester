using System.Linq;
using URLPerformanceTester.Models.Concrete;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class SitemapBuilerTests
    {
        [Fact]
        public void BuildSitemapTest()
        {
            //arrange
            var builder = new SitemapBuiler(new HtmlLinksExtractor());
            //act
            var urls = builder.BuildSitemap("https://ukad-group.com/");
            //assert
            Assert.True(urls.Count() != 0);
        }
    }
}
