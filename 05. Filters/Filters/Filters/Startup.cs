using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Filters
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(ViewResultDiagnostics));
                //options.Filters.Add(typeof(DiagnosticsFilter));
                options.Filters.Add(new MessageAttribute("This is the Globally-Scoped Filter"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();

        }
    }
}
