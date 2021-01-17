using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using PMS.Models;
using PMS.Models.HangFireModel;

[assembly: OwinStartup(typeof(PMS.App_Start.Startup))]

namespace PMS.App_Start
{
    public class Startup
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            HangfireRecordEntities db = new HangfireRecordEntities();

            var connection = db.Database.Connection.ConnectionString;

            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connection, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });
            

            yield return new BackgroundJobServer();
        }


        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/account/signin")
            });

            app.UseHangfireAspNet(GetHangfireServers);
            var option = new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizeAtrribute() }
            };
            app.UseHangfireDashboard("/Hangfire",option);      

            
        }
    }
}
