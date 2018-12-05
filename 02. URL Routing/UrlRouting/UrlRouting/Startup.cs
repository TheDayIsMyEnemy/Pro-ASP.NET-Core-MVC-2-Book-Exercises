using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace UrlRouting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Defining an Inline Custom Constraint
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                // Default route config by MVC
                routes.MapRoute(
                    name: "MyRoute",
                    template: "{controller=Home}/{action=Index}/{id?}");



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
