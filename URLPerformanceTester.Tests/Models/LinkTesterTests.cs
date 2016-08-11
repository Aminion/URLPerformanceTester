using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Concrete;

using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class LinkTesterTests
    {
        [Fact]
        public void ListOfLinksTest()
        {
            //arrange
            var tester = new UrlTester();
            var url = "https://www.google.com/";
            //act
            var result = tester.Test(url);
            //assert
            Assert.True(result != null);
            Assert.True(result.StatusCode > 0);
            Assert.True(result.Time > 0);
            Assert.True(!string.IsNullOrEmpty(result.Url));
        }

    }
}
