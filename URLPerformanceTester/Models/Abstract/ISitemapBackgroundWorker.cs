using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Abstract
{
    interface ISitemapBackgroundWorker
    {
        void Perform(IEnumerable<string> sitemapLinks, SitemapTestResult testResult);
    }
}
