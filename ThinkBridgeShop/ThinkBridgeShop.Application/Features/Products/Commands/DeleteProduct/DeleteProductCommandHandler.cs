using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct;
using ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
      

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return Unit.Value;

            });
        }

        public partial class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<DeleteProductCommand, Product>().ReverseMap();
            }
        }

        public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
        {
            public DeleteProductCommandValidator()
            {

            }


        }
    }
}

