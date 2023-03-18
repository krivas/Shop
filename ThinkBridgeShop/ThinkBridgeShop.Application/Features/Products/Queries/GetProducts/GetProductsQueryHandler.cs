using System;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;

namespace ThinkBridgeShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        public Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

