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
        public async Task Test_DeleteProduct()
        {
            var handler = new DeleteProductCommandHandler(_mockProductRepository.Object, _mapper);
            var deleteProductCommand = new DeleteProductCommand()
            {
                Id = 1,
            };
            var result = await handler.Handle(deleteProductCommand, CancellationToken.None);
            var response = await _mockProductRepository.Object.GetAllAsync(1, 8);
            response.ShouldNotBeNull();
            response.ShouldNotBeEmpty();
            var updatedProduct = response.FirstOrDefault(x => x.Id == deleteProductCommand.Id);
            updatedProduct.ShouldBeNull();
            response.Count().ShouldBe(7);
        }
    }
}

