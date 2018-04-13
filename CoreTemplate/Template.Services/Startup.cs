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
using Template.BusinessLayer.Managers.ClientInfoManager;

namespace Template.Services
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
            services.AddScoped<IRepositoryBase, RepositoryWebApi>();

            services.AddScoped<IClientInfoManager, ClientInfoManager>();

            //services.AddScoped<ITenantManager, TenantManager>();
            services.AddScoped<BusinessManagerFactory>();
            // Add framework services.


            //Redis Cache
            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "coretemplate";
                options.Configuration = "localhost";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new
                    List<string> { "index.html" }
            });
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
