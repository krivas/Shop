using System;
using AutoMapper;
using FluentValidation;
using MediatR;
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
                throw new Exception();
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

        }


    }
}

