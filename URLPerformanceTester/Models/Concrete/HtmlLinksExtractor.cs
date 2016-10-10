using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class HtmlLinksExtractor : IHtmlLinksExtractor
    {
        public IEnumerable<Uri> Extract(Uri uri, Uri baseUri)
        {
            var request = WebRequest.CreateHttp(uri);
            request.AllowAutoRedirect = true;
            request.Proxy = null;
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            try
            {
                using (var response = request.GetResponse())
                {
                    if (response.ContentType.Contains("text/html"))
                    {
                        var doc = new HtmlDocument();
                        doc.Load(response.GetResponseStream());
                        return doc.DocumentNode.SelectNodes("//a")
                            .Select(a => a.GetAttributeValue("href", null))
                            .Where(l => l != null)
                            .Select(l => new Uri(l, UriKind.RelativeOrAbsolute))
                            .Where(u => isLocal(u, baseUri) && !isHash(u))
                            .Select(u => u.IsAbsoluteUri ? u : new Uri(baseUri, u));
                    }
                    return null;
                }
            }
            catch (WebException)
            {
                return null;
            }
        }
        private bool isLocal(Uri uri, Uri baseUri) => baseUri.IsBaseOf(uri);
        private bool isHash(Uri uri) => uri.ToString().Contains('#');
    }
}