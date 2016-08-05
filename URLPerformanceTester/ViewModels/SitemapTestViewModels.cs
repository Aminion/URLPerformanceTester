using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace URLPerformanceTester.ViewModels
{
    public class SitemapTestViewModel
    {
        [Url]
        public string Url { get; set; }
    }
    public class SitemapTestOverviewViewModel
    {
        public int Id { get; set; }
        public string SitemapURL { get; set; }
        public DateTime CreationTime { get; set; }
        public int URLsCount { get; set; }
        public int URLsTested { get; set; }
    }
    public class SitemapTestDetailsViewModel
    {
        public string SitemapURL { get; set; }
        public DateTime CreationTime { get; set; }
        public int URLsCount { get; set; }
        public int URLsTested { get; set; }
        public List<URLTestResultViewModel> URLTestResults { get; set; }
    }
}