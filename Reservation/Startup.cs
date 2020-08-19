using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservation.Data;
using Reservation.DataAccess;
using Reservation.Repository;
using System;

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
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //typeOf(Startup) is added as parameter because ambigous call error was comming but need to explore this cause
            services.AddAutoMapper(typeof(Startup));
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

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();

        }
    }
}
