using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace URLPerformanceTester.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual List<SitemapTest> SitemapTests { get; set; }
    }
}