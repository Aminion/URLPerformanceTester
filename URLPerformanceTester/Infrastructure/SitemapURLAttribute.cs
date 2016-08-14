using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace URLPerformanceTester.Infrastructure
{
    public class SitemapUrlAttribute : ValidationAttribute
    {
        public SitemapUrlAttribute()
        {
            ErrorMessage = "URL doesn't contains sitemap file";
        }

        public override bool IsValid(object value)
        {
            var url = value as string;
            try
            {
                    XDocument.Load(url);
                    return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
    }
}