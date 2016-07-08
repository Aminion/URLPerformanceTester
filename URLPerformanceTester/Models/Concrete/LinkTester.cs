using System.Diagnostics;
using System.Net;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class LinkTester : IUrlTester
    {
        public TestResult Test(string url, int times)
        {
            var test = new TestResult() { Url = url };
            var sw = new Stopwatch();
            for (var i = 0; i < times; i++)
            {
                var request = WebRequest.CreateHttp(url);
                sw.Start();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    sw.Stop();
                    var elapsed = (int)sw.ElapsedMilliseconds;
                    if (elapsed > test.MaxTime) test.MaxTime = elapsed;
                    if (test.MinTime == 0) test.MinTime = elapsed;
                    else if (elapsed < test.MinTime) test.MinTime = elapsed;
                    test.AvgTime += elapsed;
                    test.StatusCode = response.StatusCode;
                    sw.Reset();
                }

            }
            test.AvgTime /= times;
            return test;
        }
    }
}