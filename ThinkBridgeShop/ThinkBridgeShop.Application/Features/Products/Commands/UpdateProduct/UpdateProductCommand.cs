using System;
using MediatR;

namespace ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

