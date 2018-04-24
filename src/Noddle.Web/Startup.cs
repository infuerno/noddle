using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noddle.Web.Models;
using Noddle.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Noddle.Web
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
            // add application services
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=noddle.db"));
            services.AddSingleton<IRotator, Rotator>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                options.Scope.Add("https://www.googleapis.com/auth/calendar");
                options.SaveTokens = true;
                // options.Events = new OAuthEvents {
                //     OnRedirectToAuthorizationEndpoint = (context) =>
                //     {
                //         if (context.Request.Path != "/Account/ExternalLogin")
                //         {
                //             context.Response.Redirect("/Account/Login");
                //             context.HandleResponse();
                //         }

                //         return Task.FromResult(0);
                //     }
                // };
            });

            // add framework services
            services.AddMvc();

            // services.AddHsts(options =>
            // {
            //     options.Preload = true;
            //     options.IncludeSubDomains = true;
            //     options.MaxAge = TimeSpan.FromDays(60);
            //     options.ExcludedHosts.Add("noddlebox.azurewebsites.net");
            // });

            // services.AddHttpsRedirection(options =>
            // {
            //     options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
            //     options.HttpsPort = 5001;
            // });
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
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Clock}/{action=Display}/{id?}");
            });
        }
    }
}
