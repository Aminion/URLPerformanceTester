using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IUrlTester
    {
        URLTestResult Test(string url, int times);
    }
}
