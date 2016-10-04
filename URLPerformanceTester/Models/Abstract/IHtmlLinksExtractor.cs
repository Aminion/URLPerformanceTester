using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IHtmlLinksExtractor
    {
        IEnumerable<string> Extract(string url);
    }
}
