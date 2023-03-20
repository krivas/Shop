using System;
using AutoMapper;

using ThinkBridgeShop.Application.Contracts.Repositories;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.UnitTests.Mocks;

namespace ThinkBridgeShop.UnitTests.Products.Queries
{
	public class GetProductsQueryHandlerTests
    {
		private readonly IMapper _mapper;
		private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
		public GetProductsQueryHandlerTests()
		{
			_mockProductRepository = ProductsMocksRepository.GetProductRepository();
			var configurationProvider = new MapperConfiguration(cfg=>
			{
				cfg.AddProfile<MappingProfile>();
			});
			_mapper = configurationProvider.CreateMapper();
		}
		[Fact]
		public async Task GetProductsTest()
		{
            var handler = new GetProductsQueryHandler(_mockProductRepository.Object,_mapper);
			var getProductQuery =new GetProductsQuery() { Page=1,PageSize=4};
			var result=await handler.Handle(getProductQuery,CancellationToken.None);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.ShouldBeOfType<List<ProductDto>>();
			result.Count().ShouldBe(4);
		}
	}
}
