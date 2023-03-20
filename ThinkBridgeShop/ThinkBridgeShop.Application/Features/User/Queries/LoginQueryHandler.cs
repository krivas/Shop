using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using ThinkBridgeShop.Application.Contracts.Identity;
using ThinkBridgeShop.Application.Features.Models.Authentication;
using ThinkBridgeShop.Application.Features.User.Commands;

namespace ThinkBridgeShop.Application.Features.User.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery,AuthenticationReponse>
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public LoginQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<AuthenticationReponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var authenticationRequest = _mapper.Map<AuthenticationRequest>(request);
           return  await _authenticationService.AuthenticateAsync(authenticationRequest);
        }
    }
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginQuery, AuthenticationRequest>().ReverseMap();
        }
    }

    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.UserName)
             .NotEmpty().WithMessage("{UserName} cannot be empty")
             .NotNull().WithMessage("{UserName} is required");



            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("{Password} cannot be empty")
             .NotNull().WithMessage("{Password} is required");

        }


    }
}

