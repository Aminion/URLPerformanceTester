using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string returnUrl)
        {
            AppUser user = null;
            var cookieId = CookieStoredUserId;
            if (CookieStoredUserId != null)
            {
                user = await UserManager.FindByIdAsync(cookieId);
                if (user == null)
                {
                    user = new AppUser();
                    await UserManager.CreateAsync(user);
                    CookieStoredUserId = user.Id;
                }
            }
            var ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignOut();
            AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
            return new RedirectResult(returnUrl);
        }
        private string CookieStoredUserId
        {
            get
            {
                return Request.Cookies[UserIdCookieName] != null ? Request.Cookies[UserIdCookieName].Value : null;
            }
            set
            {
                Response.Cookies[UserIdCookieName].Value = value;
            }
        }
        private const string UserIdCookieName = "UserId";
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}