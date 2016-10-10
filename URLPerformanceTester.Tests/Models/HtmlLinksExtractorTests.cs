using System;
using System.Linq;
using URLPerformanceTester.Models.Concrete;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class HtmlLinksExtractorTests
    {
        [Fact]
        public void ExtractionTest()
        {
            //arrange
            var extractor = new HtmlLinksExtractor();
            //act
            var result = extractor.Extract(new Uri("http://monosnap.com/page/faq"),new Uri("https://monosnap.com"));
            //assert
            Assert.True(result != null);
            Assert.True(result.Count() != 0);
        }
    }
}