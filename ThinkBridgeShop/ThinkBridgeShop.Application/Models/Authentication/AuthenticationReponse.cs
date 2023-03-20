using System;
namespace ThinkBridgeShop.Application.Features.Models.Authentication
{
	public class AuthenticationReponse
	{
		public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

