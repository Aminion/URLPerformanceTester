using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using URLPerformanceTester.Models.Concrete;

namespace URLPerformanceTester.Tests.Models
{
   public  class SitemapDocumentReaderTests
    {
        [Fact]
        public void ReadGoogleSiteMap()
        {
            //arrange
            var reader = new SitemapDocumentReader();
            XDocument doc;
            //act
            try
            {
                doc = reader.GetSitemapDocument("https://www.google.com/");
            }
            catch
            {
                //assert
                Assert.True(false, "Code has thrown exception.");
            }                
            
        }
    }
}
