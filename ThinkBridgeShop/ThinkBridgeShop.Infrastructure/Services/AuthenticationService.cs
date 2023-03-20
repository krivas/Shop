using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ThinkBridgeShop.Application.Features.Models.Authentication;
using ThinkBridgeShop.Application.Contracts.Identity;
using Microsoft.Extensions.Options;
using ThinkBridgeShop.Application.Exceptions;

namespace ThinkBridgeShop.Infrastructure.Services
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(UserManager<IdentityUser> userManager,IOptions<JwtSettings> jwtSettings)
		{
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
		}

        public async Task<AuthenticationReponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                var response =new AuthenticationReponse()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
                return response;
            }
            throw new UnAuthorizedException();
        }

        public async Task RegistrationAsync(RegistrationRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                throw new BadRequestException("Username already exists");

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new BadRequestException("User creation failed! Please create a secure password.");

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


    }
}

