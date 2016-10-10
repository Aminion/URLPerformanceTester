using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var uri = new Uri("http://monosnap.com/page/faq");
            //act
            var result = tester.Test(uri);
            //assert
            Assert.True(result != null);
            Assert.True(result.StatusCode > 0);
            Assert.True(result.Time > 0);
            Assert.True(!string.IsNullOrEmpty(result.Url.ToString()));
        }

        [Fact]
        public void Memtest()
        {
            var tester = new UrlTester();
            var sw = new Stopwatch();
            var t = new List<long>();
            for (var i = 0; i < 1000; i++)
            {
                sw.Restart();
              //  tester.Test("http://mathus.ru/olymp/fizteh9m2013.pdf");
                t.Add(sw.ElapsedMilliseconds);

            }
        }
    }
}