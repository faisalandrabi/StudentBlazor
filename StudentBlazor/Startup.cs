using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using StudentBlazor.Context;
using StudentBlazor.Data;
using StudentBlazor.IServices;
using StudentBlazor.Logic;
using StudentBlazor.Models;
using StudentBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBlazor
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
            var ConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<DataBaseContext>(opt => opt.UseSqlite(ConnectionStr));
            services.AddDbContext<DataBaseContext>(opt => opt.UseSqlite(ConnectionStr));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddTransient<IStudentService, StudentServices>();
            services.AddTransient<ICountryService, CountryServices>();
            services.AddTransient<IClassesService, ClassesServices>();
            services.AddSingleton<WeatherForecastService>();
          
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
