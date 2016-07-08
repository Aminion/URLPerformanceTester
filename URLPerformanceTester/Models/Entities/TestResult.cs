using System.Net;

namespace URLPerformanceTester.Models.Entities
{
    public class TestResult
    {
        public string Url { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int AvgTime { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}