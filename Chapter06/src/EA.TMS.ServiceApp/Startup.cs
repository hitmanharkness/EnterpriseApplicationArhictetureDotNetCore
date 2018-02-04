using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EA.TMS.BusinessLayer.Managers.TenantManagement;
using EA.TMS.DataAccess.Core;
using EA.TMS.Common.Facade;
using TMS.DataAccess.Core;
using EA.TMS.BusinessLayer.Core;
using EA.TMS.BusinessLayer.Managers.ServiceRequestManagement;

namespace EA.TMS.ServiceApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();


        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<DataContext>();       
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IServiceRequestManager, ServiceRequestManager>();
            services.AddScoped<ITenantManager, TenantManager>();
            services.AddScoped<BusinessManagerFactory>();
            // Add framework services.
            services.AddMvc();
            
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Information);
            loggerFactory.AddDebug();
           
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                ClientId = "tmsAPI",
                Authority = "http://localhost:5004",
                RequireHttpsMetadata = false,
                SignInScheme = "Cookies",

                Scope = { "openid", "profile", "roles" },
                SaveTokens = true
            });
            app.UseMvc();

        }
    }
}
