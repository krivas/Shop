using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Exceptions;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Interfaces;
using ThinkBridgeShop.Infrastructure.Repositories;

namespace ThinkBridgeShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepositoryAsync<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Price = decimal.Round(product.Price, 2, MidpointRounding.AwayFromZero);
            var exists=await _productRepository.ExistsAsync(product.Id);
            if (exists == false)
                throw new NotFoundException("Product","Id");
            else
            await _productRepository.UpdateAsync(product);
            return Unit.Value;
        }


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
            RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{Description} cannot be empty")
            .NotNull().WithMessage("{Description} is required")
            .MinimumLength(2).WithMessage("{Description} at least three letters");

            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} cannot be empty ")
            .NotNull().WithMessage("{Name} is required")
            .MinimumLength(2).WithMessage("{Name} at least three letters");

            RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{Price} cannot be empty.")
            .NotNull().WithMessage("{Price} is required.")
            .GreaterThan(0).WithMessage("{Price} must be greater than 0.");
        }


    }
}

