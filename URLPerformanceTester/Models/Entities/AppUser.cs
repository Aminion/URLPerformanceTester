using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace URLPerformanceTester.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual List<SitemapTestResult> SitemapTestResults { get; set; }
    }
}