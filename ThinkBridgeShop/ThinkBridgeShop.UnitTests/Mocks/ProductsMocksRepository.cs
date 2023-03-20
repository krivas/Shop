using System;
using Moq;
using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.UnitTests.Mocks
{
	public class ProductsMocksRepository
    {
		public static Mock<IRepositoryAsync<Product>> GetProductRepository()
		{
            var products = GetProducts();

            var mockProductRepository = new Mock<IRepositoryAsync<Product>>();


            mockProductRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Product>()))
                     .Returns(async (Product product) =>
                     {
                         var productToDelete=products.FirstOrDefault(x=>x.Id==product.Id);
                         if (productToDelete!=null)
                         products.Remove(productToDelete);
                         return Task.CompletedTask;

                     });

            mockProductRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
                     .Returns((Product product) =>
                     {
                         var productToUpdate = products.FirstOrDefault(x => x.Id == product.Id);
                         if (productToUpdate != null)
                             productToUpdate = product;
                         return Task.CompletedTask;

                     });
            mockProductRepository.Setup(x => x.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()))
                   .ReturnsAsync((int page, int pageSize) =>
                   {
                       var results = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                       return results;
                   });

            mockProductRepository.Setup(repo => repo.CreateAsync(It.IsAny<Product>()))
                     .ReturnsAsync((Product product) =>
                     {
                         products.Add(product);
                         return product;
                     });
            return mockProductRepository;
        }

		private static List<Product> GetProducts()
		{
            return new List<Product>
            {
                new Product { Id = 1, Name = "Mouse", Description = "Technology", Price = 30.00m },
                new Product { Id = 2, Name = "Keyboard", Description = "Technology", Price = 20.00m },
                new Product { Id = 3, Name = "Hammer", Description = "Tool", Price = 50.00m },
                new Product { Id = 4, Name = "Iphone", Description = "CellPhone", Price = 1000.00m },
                new Product { Id = 5, Name = "Tv", Description = "Appliance", Price = 600.00m },
                new Product { Id = 6, Name = "Mac", Description = "Laptop", Price = 2000.00m },
                new Product { Id = 7, Name = "Keyboard", Description = "Technology", Price = 0.00m },
                new Product { Id = 8, Name = "Hammer", Description = "Tool", Price = 50.00m }
            };
        }
	}
}

