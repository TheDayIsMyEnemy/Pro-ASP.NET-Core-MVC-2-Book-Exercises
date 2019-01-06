using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using UrlRouting.Infrastructure;

namespace UrlRouting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                //Defining an Inline Custom Constraint
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));

                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.Routes.Add(new LegacyRoute(
                            app.ApplicationServices,
                            "/articles/Windows_3.1_Overview.html",
                            "/old/.NET_1.0_Class_Library"));

                // Default route config by MVC
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                     name: "out",
                     template: "outbound/{controller=Home}/{action=Index}");

                //routes.MapRoute(
                //    name: "NewRoute",
                //    template: "App/Do{action}",
                //    defaults: new { controller = "Home" });

                //Custom constraint
                //inline
                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller=Home}/{action=Index}/{id:weekday?}");
                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new WeekDayConstraint() });


                //routes.MapRoute(name: "MyRoute",
                //         template: "{controller}/{action}/{id?}",
                //         defaults: new { controller = "Home", action = "Index" },
                //         constraints: new
                //         {
                //             id = new CompositeRouteConstraint(
                //                new IRouteConstraint[] {new AlphaRouteConstraint(),
                //                                        new MinLengthRouteConstraint(6)
                //         })
                //   });

                //routes.MapRoute(name: "MyRoute",
                //        template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");

                //routes.MapRoute(name: "MyRoute",
                //  template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");

                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");

                //routes.MapRoute(name: "MyRoute",
                //template: "{controller:regex(^H.*)=Home}/{action=Index}/{id?}");

                //routes.MapRoute(name: "MyRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new IntRouteConstraint() });
                //routes.MapRoute(
                //    name: "MyRoute",
                //    template: "{controller=Home}/{action=Index}/{id:int?}");


                //routes.MapRoute(
                //    name: "MyRoute",
                //    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");

                //routes.MapRoute(
                //    name: "MyRoute",
                //    template: "{controller=Home}/{action=Index}/{id=DefaultId}");

                //routes.MapRoute(
                //    name: "ShopSchema2",
                //    template: "Shop/OldAction",
                //    defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute(
                //    name: "ShopSchema",
                //    template: "Shop/{action}",
                //    defaults: new { controller = "Home" });

                //routes.MapRoute("", "X{controller}/{action}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller}/{action}",
                //    defaults: new { controller = "Home" , action = "Index" });

                //routes.MapRoute(name: "",
                //    template: "Public/{controller=Home}/{action=Index}");
            });
        }
    }
}
