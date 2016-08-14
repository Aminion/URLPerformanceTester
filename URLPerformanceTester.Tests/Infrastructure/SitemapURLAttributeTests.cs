using URLPerformanceTester.Infrastructure;
using Xunit;

namespace URLPerformanceTester.Tests.Infrastructure
{
    public class SitemapURLAttributeTests
    {
        [Fact]
        public void SitemapURLAttributeTest_ValidURL()
        {
            //arrange
            var url = "https://google.com/sitemap.xml";
            var attr = new SitemapUrlAttribute();
            //act
            var isValid = attr.IsValid(url);
            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void SitemapURLAttributeTest_InvalidURL()
        {
            //arrange
            var url = "http://referencesource.microsoft.com/sitemap.xml";
            var attr = new SitemapUrlAttribute();
            //act
            var isValid = attr.IsValid(url);
            //assert
            Assert.False(isValid);
        }
    }
}