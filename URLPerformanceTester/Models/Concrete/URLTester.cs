using System;
using System.Diagnostics;
using System.Net;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class UrlTester : IUrlTester
    {

        public RequestTest Test(Uri uri)
        {
            var test = new RequestTest() { Url = uri.ToString() };
            var sw = new Stopwatch();
            var request = WebRequest.CreateHttp(uri);
            request.AllowAutoRedirect = true;
            request.Method = "HEAD";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Proxy = null;
            try
            {
                sw.Start();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    test.Time = (int)sw.ElapsedMilliseconds;
                    test.StatusCode = response.StatusCode;
                }
                return test;
            }
            catch (WebException ex)
            {
                test.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                return test;
            }
            finally
            {               
           //     GC.Collect(2);
            }
        }
    }
}