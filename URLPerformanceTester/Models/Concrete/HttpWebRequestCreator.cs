using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class HttpWebRequestCreator : IHttpWebRequestCreator
    {
        public HttpWebRequest Create(Uri uri)
        {
            var request = WebRequest.CreateHttp(uri);
            request.AllowAutoRedirect = true;
            request.UserAgent = "testerbot";
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Proxy = null;
            return request;
        }
    }
}