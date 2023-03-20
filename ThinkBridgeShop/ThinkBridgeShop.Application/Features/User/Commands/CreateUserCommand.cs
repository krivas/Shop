using System;
using MediatR;

namespace ThinkBridgeShop.Application.Features.User.Commands
{
	public class CreateUserCommand:IRequest<Unit>
	{
		public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

