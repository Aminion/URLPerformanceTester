using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace URLPerformanceTester.Models.Entities
{
    public class SitemapTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SitemapURL { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual List<URLTest> URLTests { get; set; }
        public int TestsPerURL { get; set; }
        public int URLsCountToTest { get; set; }
    }
}