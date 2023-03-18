using System;
using AutoMapper;
using FluentValidation;
using System.Globalization;
using MediatR;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Interfaces;

namespace ThinkBridgeShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IRepositoryAsync<Product> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async  Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product=_mapper.Map<Product>(request);
            product.Price = decimal.Round(product.Price, 2, MidpointRounding.AwayFromZero);
            var response=await _productRepository.CreateAsync(product);
            return Unit.Value;
        }



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

