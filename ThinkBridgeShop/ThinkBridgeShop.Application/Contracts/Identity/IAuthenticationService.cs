using System;
using ThinkBridgeShop.Application.Features.Models.Authentication;

namespace ThinkBridgeShop.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationReponse> AuthenticateAsync(AuthenticationRequest request);
        Task RegistrationAsync(RegistrationRequest request);
    }
}

