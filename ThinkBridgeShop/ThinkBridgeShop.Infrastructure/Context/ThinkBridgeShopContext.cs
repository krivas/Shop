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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;

                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
	}
}

