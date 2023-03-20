using System;
using System.ComponentModel.DataAnnotations;

namespace ThinkBridgeShop.Application.Features.Models.Authentication
{
	public class RegistrationRequest
	{

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

