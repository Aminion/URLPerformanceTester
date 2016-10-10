using System;
using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapBackgroundTester
    {
        void Perform(Uri uri, int sitemapTestId);
    }
}