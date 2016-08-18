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
        private readonly IApproximativeModeAlgorithm _modeAlgorithm;

        public RequestBackgroundTester(IGenericRepository<RequestTestSet> sitemapTestsRepo, IUrlTester urlTesterTester,
            IApproximativeModeAlgorithm modeAlgorithm)
        {
            _sitemapTestsRepo = sitemapTestsRepo;
            _urlTester = urlTesterTester;
            _modeAlgorithm = modeAlgorithm;
        }

        public void Perform(IEnumerable<string> sitemapUrLs, int sitemapTestId)
        {
            var sitemapTest = _sitemapTestsRepo.FindBy(t => t.Id == sitemapTestId).First();
            var minTime = 0;
            var maxTime = 0;
            foreach (var url in sitemapUrLs)
            {
                var urlTest = _urlTester.Test(url);
                if (urlTest.Time > maxTime) maxTime = urlTest.Time;
                if (urlTest.Time < minTime || minTime == 0) minTime = urlTest.Time;
                sitemapTest.UrlTests.Add(urlTest);
                _sitemapTestsRepo.Save();
            }
            sitemapTest.MinTime = minTime;
            sitemapTest.MaxTime = maxTime;
            sitemapTest.ModeTime = _modeAlgorithm.Mode(sitemapTest.UrlTests.Select(t => t.Time), 10);
            _sitemapTestsRepo.Save();
        }
    }
}