using System;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_Runners.Frontend.Api;
using Project_Runners.Frontend.Extensions;
using Project_Runners.Frontend.ViewServices;

namespace Project_Runners.Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAntDesign();
            services.AddAutoMapper(GetType().Assembly);
            
            services.AddHttpClient<IRunsApi, RunsApi>(client => client.ConfigureAsHttp2(Configuration));
            services.AddHttpClient<IRunnersApi, RunnersApi>(client => client.ConfigureAsHttp2(Configuration));
            
            services.AddTransient<IRunnersService, RunnersService>();
            services.AddTransient<IRunsService, RunsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}