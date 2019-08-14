using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DataContext;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }   
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });
            // services.AddDbContextPool<Delete>(options => options.UseNpgsql(Configuration.GetConnectionString("Myconn")));
            services.AddMvc();
            services.AddDbContext<EmployeeContext>(item => item.UseNpgsql(Configuration.GetConnectionString("MyConn")));
            services.AddScoped<IEmployeeRepository , SQLEmployeeRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;

            }).AddEntityFrameworkStores<EmployeeContext>();
            // For adding the Identity Services in the Dependency Injection Here

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseStaticFiles(); // These are the Http request Processing Middlewares as they Intercept the Requests and Responses 
            app.UseAuthentication();
            // Here we want to Authenticate the Usres before the Request reaches the User Here
            app.UseMvc(routes =>
            {
              //  routes.MapRoute("default", "{controller=Home}/{action=Grid}");
                routes.MapRoute("default", "{controller=Home}/{action=Grid}/{id?}", new { id = 8 });// Here ? Indicates That without id it will also Find the Default resource from the Database
            });

        }
    }
}