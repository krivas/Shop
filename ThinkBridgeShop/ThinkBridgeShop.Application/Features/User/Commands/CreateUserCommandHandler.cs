using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Contracts.Identity;
using ThinkBridgeShop.Application.Features.Models.Authentication;
using ThinkBridgeShop.Application.Features.Products.Queries.GetProducts;
using ThinkBridgeShop.Domain.Dtos;
using ThinkBridgeShop.Domain.Entities;

namespace ThinkBridgeShop.Application.Features.User.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IAuthenticationService authenticationService,IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var registrationRequest=_mapper.Map<RegistrationRequest>(request);
            await _authenticationService.RegistrationAsync(registrationRequest);
            return Unit.Value;
        }
    }

    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, RegistrationRequest>().ReverseMap();
        }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName)
             .NotEmpty().WithMessage("{UserName} cannot be empty")
             .NotNull().WithMessage("{UserName} is required")
             .MinimumLength(2).WithMessage("{UserName} at least three letters");

            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("{Email} cannot be empty")
             .NotNull().WithMessage("{Email} is required");

            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("{Password} cannot be empty")
             .NotNull().WithMessage("{Password} is required")
             .MinimumLength(7).WithMessage("{Password} at least eight letters");
        }


    }
}

