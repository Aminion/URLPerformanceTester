using System.Linq;
using System.Web.Mvc;
using System;
using System.Net;
using Microsoft.AspNet.Identity;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.ViewModels;
using URLPerformanceTester.Models.Entities;
using URLPerformanceTester.Models.Abstract;
using Hangfire;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly AppUserManager _userManager;
        private AppUser _currentUser;
        private AppUser CurrentUser => _currentUser ?? (_currentUser = _userManager.FindById(User.Identity.GetUserId()));
        private readonly ISitemapExtractor _urlExtractor;
        private readonly IBackgroundTaskManager<ISitemapBackgroundTester> _backgroundTaskManager;

        public TestsController(AppUserManager userManager, ISitemapExtractor urlExtractor,
            IBackgroundTaskManager<ISitemapBackgroundTester> backgroundTaskManager)
        {
            _userManager = userManager;
            _urlExtractor = urlExtractor;
            _backgroundTaskManager = backgroundTaskManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var result = user.SitemapTests.Select(st => new RequestTestsSetOverviewViewModel
            {
                Id = st.Id,
                CreationTime = st.CreationTime,
                RequestUrl = st.SitemapUrl,
                UrLsCount = st.UrLsCount,
                UrLsTested = st.UrlTests.Count
            }
                ).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RequestTestsSetViewModel());
        }

        [HttpPost]
        public ActionResult Create(RequestTestsSetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var urls = _urlExtractor.TryExtract(model.UrlWithSitemapPrefix).ToList();
                    var test = new RequestTestSet()
                    {
                        SitemapUrl = model.Url,
                        CreationTime = DateTime.UtcNow,
                        UrLsCount = urls.Count
                    };
                    CurrentUser.SitemapTests.Add(test);
                    _userManager.Update(CurrentUser);
                    _backgroundTaskManager.AddTask(t => t.Perform(urls, test.Id));
                    return RedirectToAction("Details", new {id = test.Id});
                }
                catch (WebException)
                {
                    ModelState.AddModelError("Sitemap Error", "Unable to read URL sitemap");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var test = CurrentUser.SitemapTests.Find(t => t.Id == id);
            if (test == null) return new HttpNotFoundResult();
            var model = new RequestTestsSetDetailsViewModel()
            {
                CreationTime = test.CreationTime,
                RequestUrl = test.SitemapUrl,
                UrLsCount = test.UrLsCount,
                UrLsTested = test.UrlTests.Count,
                MinTime = test.MinTime,
                MaxTime = test.MaxTime,
                UrlTestResults = test.UrlTests.Select(t => new RequestTestViewModel()
                {
                    Time = t.Time,
                    StatusCode = t.StatusCode,
                    Url = t.Url,
                }).OrderByDescending(t => t.Time).ToList()
            };
            return View(model);
        }
    }
}