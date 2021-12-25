using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreShop.BusinessLogic;
using StoreShop.Data;
using StoreShop.DataAccess;
using StoreShop.Presentation.Controllers;
using StoreShop.Repository;
using System;
using StoreShop.Presentation.Support;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;

namespace StoreShop.Presentation
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

            //Register context service using dependancy injection and this context service will read connection string using option builder in dbcontext constructor             
            services.AddDbContext<StoreShopDataContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddRazorRuntimeCompilation();

            // To call one controller from another controller, so we are registring as service
            services.AddMvc().AddControllersAsServices();

            //The Distributed Memory Cache (AddDistributedMemoryCache) is a framework-provided implementation 
            //of IDistributedCache that stores items in memory. Cached items are stored by the app instance on the server where the app is running.
            services.AddDistributedMemoryCache();           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Dependancy Injection           
            services.RegisterDI();            
            

            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreShop";
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                //options.Cookie.MaxAge = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //typeOf(Startup) is added as parameter because ambigous call error was comming but need to explore this cause
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddGoogle(Options =>
                {
                    Options.ClientId = Configuration.GetSection("GoogleAuthetication").GetSection("ClientId").Value;
                    Options.ClientSecret = Configuration.GetSection("GoogleAuthetication:ClientSecret").Value;
                });

            //Bult-in identity service     
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StoreShopDataContext>();
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["AzuriteConnectionString:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["AzuriteConnectionString:queue"], preferMsi: true);
            });

            //services.AddSingleton(_=> 
            //return new BlobServiceClient(Configuration.Get
            //)
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

            app.UseAuthentication();
            app.UseAuthorization();// for identity service

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
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }


}
