using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Application.Contracts.Repositories;
using System.Collections.Generic;

namespace ThinkBridgeShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IRepositoryAsync<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {   
           var products=await _productRepository.GetAllAsync(request.Page,request.PageSize);
            return  _mapper.Map<List<ProductDto>>(products); ;
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
            RuleFor(p => p.PageSize)
            .GreaterThan(0).WithMessage("{PageSize} must be greater than 0.");

            RuleFor(p => p.Page)
            .GreaterThan(0).WithMessage("{Page} must be greater than 0.");
        }


    }
}

