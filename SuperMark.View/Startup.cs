using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperMark.View.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using MudBlazor.Services;
using System.Threading.Tasks;
using SuperMark.Aplication.Store.Interfaces;

using Microsoft.AspNetCore.Components.Authorization;
using SuperMark.View.Auth;
using SuperMark.Common;

namespace SuperMark.View
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient(typeof(IAppStore), typeof(AppStore));
        
            AppState costsContext = new AppState();
      
            services.AddScoped(m => costsContext);
            services.AddScoped<SuperMarketStateProvider>();
            services.AddScoped<AuthenticationStateProvider, SuperMarketStateProvider>(prov => prov.GetRequiredService<SuperMarketStateProvider>());

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
                app.UseExceptionHandler("/Error");
            }

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
