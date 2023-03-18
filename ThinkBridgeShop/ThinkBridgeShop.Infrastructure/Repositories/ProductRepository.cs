using System;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Context;

namespace ThinkBridgeShop.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ThinkBridgeShopContext context) : base(context)
        {
        }
    }
}

