using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Concrete;
using URLPerformanceTester.Models.Entities;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class SitemapBackgroundTesterTests
    {
        [Fact]
        void PerformTest()
        {
            //arrange
            var test = new RequestTestSet()
            {
                Id = 1,
                UrlTests = new List<RequestTest>()
            };
            var testsList = new List<RequestTestSet>() { test };

            var savedTimes = 0;
            var sitemapRepoMock = new Mock<IGenericRepository<RequestTestSet>>();
            sitemapRepoMock.Setup(repo => repo.FindBy(It.IsAny<Expression<Func<RequestTestSet, bool>>>()))
                .Returns((Expression<Func<RequestTestSet, bool>> exp) => testsList.AsQueryable().Where(exp));
            sitemapRepoMock.Setup(repo => repo.Save()).Callback((() => savedTimes++));


            var urlTesterMock = new Mock<IUrlTester>();
            urlTesterMock.Setup(tester => tester.Test(It.IsAny<Uri>()))
                .Returns((string url) => new RequestTest() { Url = url });

            var backgroundTester = new SitemapBackgroundTester(sitemapRepoMock.Object, urlTesterMock.Object, new ApproximativeModeAlgorithm(),
                new SitemapDeterminant(new SitemapReader(), new SitemapBuiler(new HtmlLinksExtractor())));
            //act
            backgroundTester.Perform(new Uri("http://mathus.ru"), 1);
            //assert
            Assert.True(test.UrlTests.Count == 3);
            Assert.True(savedTimes == test.UrlTests.Count + 1);
        }
    }
}