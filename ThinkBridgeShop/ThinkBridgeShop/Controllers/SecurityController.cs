using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ThinkBridgeShop.Application.Features.User.Commands;
using ThinkBridgeShop.Application.Features.User.Queries;
using ThinkBridgeShop.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkBridgeShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SecurityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        private readonly IMediator _mediator;
        public SecurityController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            var response=await _mediator.Send(loginQuery);
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand createsUserCommand)
        {
            var response = await _mediator.Send(createsUserCommand);
            return Ok(response);
        }
    }


}

