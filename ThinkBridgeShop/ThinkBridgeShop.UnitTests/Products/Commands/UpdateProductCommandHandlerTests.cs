using System;
using AutoMapper;
using Moq;
using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.UnitTests.Mocks;

namespace ThinkBridgeShop.UnitTests.Products.Commands
{
	public class UpdateProductCommandHandlerTests
	{
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
        public UpdateProductCommandHandlerTests()
        {
            _mockProductRepository = ProductsMocksRepository.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Test_UpdateProduct()
        {
            var handler = new UpdateProductCommandHandler(_mockProductRepository.Object, _mapper);
            var updateProductCommand = new UpdateProductCommand()
            {
                Id = 1,
                Price = 30,
                Name = "CPU",
                Description = "Electronic"
            };
            var result = await handler.Handle(updateProductCommand, CancellationToken.None);
            var response = await _mockProductRepository.Object.GetAllAsync(1, 9);
            response.ShouldNotBeNull();
            response.ShouldNotBeEmpty();
            var updatedProduct = response.FirstOrDefault(x => x.Id == updateProductCommand.Id);
            updatedProduct.ShouldNotBeNull();
            updatedProduct.Price.ShouldBe(updateProductCommand.Price);
            updatedProduct.Name.ShouldBe(updateProductCommand.Name);
            updatedProduct.Description.ShouldBe(updateProductCommand.Description);
            response.Count().ShouldBe(8);
        }
    }
}

