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
            var tester = new URLTester();
            var urls = new List<string>()
            {
                "https://habrahabr.ru/",
                "https://www.google.com/",
                "https://www.youtube.com/"
            };
            //act
            var results = urls.Select(url => tester.Test(url, 3)).ToList();
            //assert
            Assert.True(results.Count == 3);
            foreach (var result in results)
            {
                Assert.True(result.StatusCode > 0);
                Assert.True(result.MinTime > 0);
                Assert.True(result.MaxTime > 0);
                Assert.True(result.AvgTime >= result.MinTime && result.AvgTime <= result.MaxTime);
                Assert.True(!string.IsNullOrEmpty(result.URL));
            }

        }
    }
}
