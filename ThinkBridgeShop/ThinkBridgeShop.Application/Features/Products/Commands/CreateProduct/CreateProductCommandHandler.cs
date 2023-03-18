using System;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;

namespace ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

