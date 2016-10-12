using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using URLPerformanceTester.Models.Concrete;

namespace URLPerformanceTester.Infrastructure
{
    public class AccessibleURLAttribute : ValidationAttribute
    {
        public AccessibleURLAttribute()
        {
            ErrorMessage = "URL is wrong or unaccesible.";
        }
        public override bool IsValid(object value)
        {
            var url = value as string;
            if (url == null) return false;
            try
            {
                var request = new HttpWebRequestCreator().Create(new Uri(url));
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK) return true;
                }
            }
            catch (WebException)
            {
                return false;
            }
            return false;
        }
    }
}