using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using URLPerformanceTester.Infrastructure;
using System.Web.Mvc;

namespace URLPerformanceTester
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<AppUserManager>());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}