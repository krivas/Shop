using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;
using ThinkBridgeShop.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Infrastructure.Context;

namespace ThinkBridgeShop.Infrastructure
{

   public static class DataServicesRegistration
   {
      public static void AddDataServicesRegistration(this IServiceCollection services, IConfiguration configuration)
       {
         services.AddDbContext<ThinkBridgeShopContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



       }
    }
    
}

