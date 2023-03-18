using System;
using MediatR;

namespace ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommand : IRequest<Unit>
	{
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}

