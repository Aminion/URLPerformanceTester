using System.Net;

namespace URLPerformanceTester.ViewModels
{
    public class URLTestResultViewModel
    {
        public string URL { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int AvgTime { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}