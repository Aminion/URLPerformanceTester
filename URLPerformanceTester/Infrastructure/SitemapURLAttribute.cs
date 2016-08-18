using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace URLPerformanceTester.Infrastructure
{
    public class SitemapUrlAttribute : ValidationAttribute
    {
        public SitemapUrlAttribute()
        {
            ErrorMessage = "URL doesn't contains  sitemap file";
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
                ErrorMessage = "URL doesn't contains  sitemap file";
                return false;
            }
            catch (XmlException ex)
            {
                ErrorMessage = "Sitemap from URL is incorrect";
                return false;
            }
        }
    }
}