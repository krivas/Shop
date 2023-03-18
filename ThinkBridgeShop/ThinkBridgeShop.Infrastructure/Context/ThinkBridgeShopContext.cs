using System;
using Microsoft.EntityFrameworkCore;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Infrastructure.Context
{
	public class ThinkBridgeShopContext : DbContext
	{
        public ThinkBridgeShopContext(DbContextOptions<ThinkBridgeShopContext> options)
         : base(options)
        {
        }
        public DbSet<Product> Producs { get; set; }
	}
}

