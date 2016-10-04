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
            var result = extractor.Extract("http://mathus.ru/math/index.php");
            //assert
            Assert.True(result != null);
            Assert.True(result.Count() != 0);
        }
    }
}