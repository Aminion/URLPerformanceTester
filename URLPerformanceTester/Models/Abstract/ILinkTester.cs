using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IUrlTester
    {
        TestResult Test(string url, int times);
    }
}
