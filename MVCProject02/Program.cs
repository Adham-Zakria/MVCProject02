using Microsoft.AspNetCore.Routing.Constraints;

namespace MVCProject02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configurations

            builder.Services.AddControllersWithViews();

            #endregion

            var app = builder.Build();


            #region Configure HTTP Request

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.MapGet(pattern: "/", requestDelegate: async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 });

            app.MapGet("/Test", async context => // Static Segment
               {
                   await context.Response.WriteAsync("Hello Test!");
               });

            app.MapGet("/{name}", async context => // Variable Segment
            {
                //var name=context.GetRouteValue("name");
                var name=context.Request.RouteValues["name"]; 
                await context.Response.WriteAsync($"Hello {name}");
            });

            app.MapGet("/Fixed{name}", async context => // Mixed Segment
            {
                var name = context.GetRouteValue("name");
                await context.Response.WriteAsync($"Hello Fixed {name}");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}"
                );

            //app.MapControllerRoute(
            //    name: "Route01",
            //    pattern: "{controller=Movies}/{action=GetMovie}/{id?}");

            app.MapControllerRoute(
                name: "Route02",
                pattern: "{controller}/{action}/{id:int?}/{name:alpha}",
                defaults: new { Controller = "Movies", action= "GetMovie" } 
               // constraints: new {id= @"\d{2}"}
                );


            app.Run();

            #endregion
        }
    }
}
