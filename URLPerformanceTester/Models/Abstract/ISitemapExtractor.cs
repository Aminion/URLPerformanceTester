using System.Collections.Generic;
using System.Xml.Linq;

namespace URLPerformanceTester.Models.Abstract
{
  public   interface ISitemapExtractor
    {
        IEnumerable<string> TryExtract(string sitemapUrl);
    }
}
