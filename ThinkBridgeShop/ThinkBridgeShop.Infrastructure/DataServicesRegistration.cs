using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;
using ThinkBridgeShop.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Infrastructure.Context;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Repositories;
using ThinkBridgeShop.Application.Features.Models.Authentication;
using ThinkBridgeShop.Infrastructure.Services;
using ThinkBridgeShop.Application.Contracts.Identity;

namespace ThinkBridgeShop.Infrastructure
{

   public static class DataServicesRegistration
   {
      public static void AddDataServicesRegistration(this IServiceCollection services, IConfiguration configuration)
       {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRepositoryAsync<Product>, ProductRepository>();
           services.AddDbContext<ThinkBridgeShopContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
       }
    }
    
}

