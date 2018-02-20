using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.DataAccess.Core;
using Template.BusinessLayer.Managers.ServiceRequestManagement;
using Template.BusinessLayer.Managers.TenantManagement;
using Template.BusinessLayer.Core;

namespace Template.ServicesApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
