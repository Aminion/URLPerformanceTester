using System.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLPerformanceTester.Models.Entities
{
    public class URLTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string URL { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int AvgTime { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}