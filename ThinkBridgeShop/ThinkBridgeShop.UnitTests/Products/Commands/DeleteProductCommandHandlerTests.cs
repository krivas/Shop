using System;
using AutoMapper;
using Moq;
using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Domain.Entities;


namespace ThinkBridgeShop.UnitTests.Products.Commands
{
	public class DeleteProductCommandHandlerTests
	{
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
        public DeleteProductCommandHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
    }
}

