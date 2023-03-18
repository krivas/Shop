using System;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct;

namespace ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
      

        public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

