using System;
using Microsoft.OpenApi.Models;
using ThinkBridgeShop.Application;

namespace ThinkBridgeShop
{
    public static class StartupExtension
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddApplicationServices();
            return builder.Build();
        }

        public static void AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ThinkBridge Shop API",
                    Description = "ThinkBridge Shop API Swagger Surface",
                    Contact = new OpenApiContact
                    {
                        Name = "Kevin Rivas",
                        Email = "krivas.reyes@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/krivasreyes/")
                    }
                });
            });
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (!app.Environment.IsDevelopment())
            {

            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;

            app.Run();
            return app;
        }
    }
}

