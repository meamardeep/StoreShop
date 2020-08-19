using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservation.Repository;
using Reservation.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Presentation
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
            services.AddControllersWithViews();

            //Register context service using dependancy injection and this context service will read 
            //connection string using opstion builder in dbcontext constructor 
            services.AddDbContext<ReservationDataContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddRazorRuntimeCompilation();
                    
            //The Distributed Memory Cache (AddDistributedMemoryCache) is a framework-provided implementation 
            //of IDistributedCache that stores items in memory. Cached items are stored by the app instance on the server 
            //where the app is running.
            services.AddDistributedMemoryCache();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Dependancy Injection
            services.AddScoped<Reservation.BusinessLogic.IUserManagement, Reservation.BusinessLogic.UserManagement>();
            services.AddScoped<IUser, UserRepo>();
            #endregion

            services.AddSession(options => 
            {
                options.Cookie.Name = "Reservation Session Cookie";
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           

            app.UseCors();
            app.UseAuthorization();

            //The order of middleware is important. Call UseSession() after UseRouting and before UseEndpoints.
            app.UseSession();
            SessionManager.Services = app.ApplicationServices;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
