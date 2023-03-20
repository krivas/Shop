using System;

using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.UnitTests.Mocks;

namespace ThinkBridgeShop.UnitTests.Products.Commands
{
	public class CreateProductCommandHandlerTests
	{
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
        public CreateProductCommandHandlerTests()
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
            var handler = new CreateProductCommandHandler(_mockProductRepository.Object, _mapper);
            var createProductCommand = new CreateProductCommand()
            {
                Price=30,
                Name="Hammer",
                Description="Tool"
            };
            var result = await handler.Handle(createProductCommand, CancellationToken.None);
            var response=await _mockProductRepository.Object.GetAllAsync(1, 9);
            var product=response.FirstOrDefault(x => x.Price == createProductCommand.Price && x.Name == createProductCommand.Name && x.Description == createProductCommand.Description);
            product.Price.ShouldBe(createProductCommand.Price);
            product.Name.ShouldBe(createProductCommand.Name);
            product.Description.ShouldBe(createProductCommand.Description);
            response.Count().ShouldBe(9);
        }
    }
}

