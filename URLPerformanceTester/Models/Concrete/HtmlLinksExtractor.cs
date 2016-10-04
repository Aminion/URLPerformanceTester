using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class HtmlLinksExtractor : IHtmlLinksExtractor
    {
        public IEnumerable<string> Extract(string url)
        {
            var result = new List<string>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.ContentType.Contains("text/html"))
                {
                    var doc = new HtmlDocument();
                    doc.Load(response.GetResponseStream());
                    return doc.DocumentNode.SelectNodes("//a")
                        .Select(p => p.GetAttributeValue("href", null))
                        .Where(p => p != null);
                }
            }
            return null;
        }
    }
}