
using System.Xml.Linq;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapDocumentReader
    {
        XDocument GetSitemapDocument(string url);
    }
}
