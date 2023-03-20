using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using ThinkBridgeShop.Application;
using ThinkBridgeShop.Infrastructure;
using ThinkBridgeShop.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ThinkBridgeShop.Middlewares;
using ThinkBridgeShop.Application.Features.Models.Authentication;

namespace ThinkBridgeShop
{
    public static class StartupExtension
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddDataServicesRegistration(builder.Configuration);
            builder.Services.AddJwtToken(builder.Configuration);
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
        public static void AddJwtToken(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddIdentity<IdentityUser, IdentityRole>(cfg => cfg.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ThinkBridgeShopContext>().AddDefaultTokenProviders();

            var audience = configuration["JwtSettings:Audience"];
            var issuer = configuration["JwtSettings:Issuer"];
            var key = configuration["JwtSettings:Key"];
            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
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
            app.UseCustomExceptionHandler();
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

