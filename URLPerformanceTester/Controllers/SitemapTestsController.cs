using System.Linq;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.ViewModels;
using URLPerformanceTester.Models.Entities;
using URLPerformanceTester.Models.Abstract;
using Hangfire;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class SitemapTestsController : Controller
    {
        private readonly AppUserManager _userManager;
        public SitemapTestsController(AppUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var result = user.SitemapTests.Select(st => new SitemapTestOverviewViewModel
            {
                Id = st.Id,
                CreationTime = st.CreationTime,
                SitemapURL = st.SitemapURL,
                URLsCount = st.URLsCountToTest,
                URLsTested = st.URLTests.Count
            }
            ).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new SitemapTestViewModel());
        }

        [HttpPost]
        public ActionResult Create(SitemapTestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var test = new SitemapTest() { SitemapURL = model.Url, CreationTime = DateTime.UtcNow };
                BackgroundJob.Enqueue<IURLTester>(t => t.Test("", 4));
                var user = _userManager.FindById(User.Identity.GetUserId());
                user.SitemapTests.Add(test);
                _userManager.Update(user);
                return RedirectToAction("Details", new { id = test.Id });
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var test = user.SitemapTests.Find(t => t.Id == id);
            if (test == null) return new HttpNotFoundResult();
            var model = new SitemapTestDetailsViewModel()
            {
                CreationTime = test.CreationTime,
                SitemapURL = test.SitemapURL,
                URLsCount = test.URLsCountToTest,
                URLsTested = test.URLTests.Count,
                URLTestResults = test.URLTests.Select(t => new URLTestResultViewModel()
                {
                    AvgTime = t.AvgTime,
                    MinTime = t.MinTime,
                    MaxTime = t.MaxTime,
                    StatusCode = t.StatusCode,
                    URL = t.URL
                }).ToList()
            };
            return View(model);
        }
    }
}