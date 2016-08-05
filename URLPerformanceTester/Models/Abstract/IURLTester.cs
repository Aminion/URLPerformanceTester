using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IURLTester
    {
        URLTest Test(string url, int times);
    }
}
