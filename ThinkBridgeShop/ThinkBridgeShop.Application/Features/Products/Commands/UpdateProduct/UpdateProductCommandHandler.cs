using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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
                CreateMap<UpdateProductCommand, Product>().ReverseMap();
            }
        }

        public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
        {
            public UpdateProductCommandValidator()
            {

            }


        }
    }
}

