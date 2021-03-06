﻿using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using AutoMapper;
using Infrastructure.Data.Repositories;
using KedaiRuncitWeb.Interfaces;
using KedaiRuncitWeb.Services;

namespace KedaiRuncitWeb
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RuncitContext>(options => options.UseSqlServer(_configuration.GetConnectionString("RuncitConnection")));

            services.AddAutoMapper();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IItemViewModelService, ItemViewModelService>();

            services.AddAntiforgery();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStaticFiles();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs/RuncitWeb-{Date}.txt"))
                .CreateLogger();

            loggerFactory.AddSerilog();

            app.UseMvc(ConfigureRoutes);

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Home/index

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
