using System;
using AutoMapper;
using FluentValidation;
using System.Globalization;
using MediatR;
using ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public async  Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
                CreateMap<CreateProductCommand, Product>().ReverseMap();
            }
        }

        public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
        {
            public CreateProductCommandValidator()
            {

            }

           
        }

    }
}

