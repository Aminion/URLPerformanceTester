using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace URLPerformanceTester.Models.Entities
{
    public class SitemapTestResult
    {
        public string SitemapURL { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationTime { get; set; }
        public int URLsCount { get; set; }
        public virtual List<URLTestResult> URLTestResults { get; set; }
    }
}