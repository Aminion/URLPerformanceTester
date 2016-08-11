using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class RequestBackgroundTester : ISitemapBackgroundTester
    {
        private readonly IGenericRepository<RequestTestSet> _sitemapTestsRepo;
        private readonly IUrlTester _urlTester;

        public RequestBackgroundTester(IGenericRepository<RequestTestSet> sitemapTestsRepo, IUrlTester urlTesterTester)
        {
            _sitemapTestsRepo = sitemapTestsRepo;
            _urlTester = urlTesterTester;
        }

        public void Perform(IEnumerable<string> sitemapUrLs, int sitemapTestId)
        {
            var sitemapTest = _sitemapTestsRepo.FindBy(t => t.Id == sitemapTestId).First();
            foreach (var url in sitemapUrLs)
            {
                var urlTest = _urlTester.Test(url);
                if (urlTest.Time > sitemapTest.MaxTime) sitemapTest.MaxTime = urlTest.Time;
                if (urlTest.Time < sitemapTest.MinTime || sitemapTest.MinTime == 0) sitemapTest.MinTime = urlTest.Time;
                sitemapTest.UrlTests.Add(urlTest);
                _sitemapTestsRepo.Save();
            }
        }
    }
}