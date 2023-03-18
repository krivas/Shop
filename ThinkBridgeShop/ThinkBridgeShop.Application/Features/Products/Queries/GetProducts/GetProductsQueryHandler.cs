using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return new List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Id=1,
                        Name="Hammer",
                        Description="Tool",
                        Price=20
                     }
                };

            });
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

