using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Interfaces;

namespace ThinkBridgeShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IRepositoryAsync<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {   
           var products=await _productRepository.GetAllAsync();
            return  _mapper.Map<ProductDto[]>(products); ;
        }
    }

    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }

    public class GetProductQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductQueryValidator()
        {

        }


    }
}

