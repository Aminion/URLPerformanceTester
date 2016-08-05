using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class URLBackgroundTester : ISitemapBackgroundTester
    {
        private IGenericRepository<SitemapTest> _sitemapTestsRepo;
        private URLTester _URLTester;
        public URLBackgroundTester(IGenericRepository<SitemapTest> sitemapTestsRepo, URLTester linkTester)
        {
            _sitemapTestsRepo = sitemapTestsRepo;
            _URLTester = linkTester;
        }
        public void Perform(IEnumerable<string> sitemapURLs, int sitemapTestId)
        {
            var sitemapTest = _sitemapTestsRepo.FindBy(t => t.Id == sitemapTestId).First();
            foreach (var url in sitemapURLs)
            {
                sitemapTest.URLTests.Add(_URLTester.Test(url, sitemapTest.TestsPerURL));
                _sitemapTestsRepo.Save();
            }
        }
    }
}