using Owin;
using System;
using Hangfire;
using Hangfire.SqlServer;


namespace URLPerformanceTester
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireTasksDb", new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }

    }
}