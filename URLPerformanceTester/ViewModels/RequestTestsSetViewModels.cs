﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using URLPerformanceTester.Infrastructure;

namespace URLPerformanceTester.ViewModels
{
    public class RequestTestsSetViewModel
    {
        [Url] 
        [AccessibleURL]      
        public string Url { get; set; }     
    }

    public class RequestTestsSetOverviewViewModel
    {
        public int Id { get; set; }
        public string RequestUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public int UrLsCount { get; set; }
        public int UrLsTested { get; set; }
        public bool IsCompleted => UrLsCount == UrLsTested;
    }

    public class RequestTestsSetDetailsViewModel
    {
        public string RequestUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int ModeTime { get; set; }
        public int UrLsCount { get; set; }
        public int UrLsTested { get; set; }
        public List<RequestTestViewModel> UrlTestResults { get; set; }
    }
}