using System;
using MediatR;

namespace ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}

