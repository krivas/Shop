using System;
using MediatR;
using ThinkBridgeShop.Application.Features.Models.Authentication;

namespace ThinkBridgeShop.Application.Features.User.Queries
{
	public class LoginQuery : IRequest<AuthenticationReponse>
	{
		public string Password { get; set; }
		public string UserName { get; set; }
	}
}

