using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Exceptions;
using ThinkBridgeShop.Domain.Entities;
using ThinkBridgeShop.Infrastructure.Interfaces;

namespace ThinkBridgeShop.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IRepositoryAsync<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Price = decimal.Round(product.Price, 2, MidpointRounding.AwayFromZero);
            var exists = await _productRepository.ExistsAsync(product.Id);
            if (exists)
                await _productRepository.DeleteAsync(product);
            else
                throw new NotFoundException();

            return Unit.Value;
        }

       
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
            RuleFor(x => x.Id)
             .NotNull()
             .GreaterThan(0);

        }


    }
}

