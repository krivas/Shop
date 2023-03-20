using System;

using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;

using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.UnitTests.Mocks;

namespace ThinkBridgeShop.UnitTests.Products.Commands
{
	public class DeleteProductCommandHandlerTests
	{
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
        public DeleteProductCommandHandlerTests()
        {
            _mockProductRepository = ProductsMocksRepository.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Test_CreateProduct()
        {
           
        }
    }
}

