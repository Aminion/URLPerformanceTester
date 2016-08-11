using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Net;

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
            var request = WebRequest.CreateHttp(url);
            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                return false;
            }
        }
    }
}