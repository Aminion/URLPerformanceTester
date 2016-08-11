using System.Diagnostics;
using System.Net;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class UrlTester : IUrlTester
    {
        public RequestTest Test(string url)
        {
            var test = new RequestTest() {Url = url};
            var sw = new Stopwatch();
            var request = WebRequest.CreateHttp(test.Url);
            sw.Start();
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                sw.Stop();
                test.Time = (int) sw.ElapsedMilliseconds;
                test.StatusCode = response.StatusCode;
            }
            return test;
        }
    }
}