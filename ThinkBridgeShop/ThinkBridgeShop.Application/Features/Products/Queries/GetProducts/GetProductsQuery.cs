using System;
using MediatR;
using ThinkBridgeShop.Domain.Dtos;

namespace ThinkBridgeShop.Application.Features.Products.Queries.GetProducts
{
	public class GetProductsQuery: IRequest<IEnumerable<ProductDto>>
	{
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}

