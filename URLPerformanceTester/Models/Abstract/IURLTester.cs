﻿using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IUrlTester
    {
        RequestTest Test(string url);
    }
}
