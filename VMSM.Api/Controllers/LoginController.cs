using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Models;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route(Routes.Login.Root)]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            var loginResult = new LoginResult();

            if (!result.Succeeded)
            {
                loginResult.Successful = false;
                loginResult.Error = "Username and password are invalid.";

                return BadRequest(loginResult);
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            loginResult.Successful = true;
            loginResult.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(loginResult);
        }

        [HttpPost]
        [Route(Routes.Logout.Root)]
        public async Task<IActionResult> Logout()
        {           
            await _signInManager.SignOutAsync();

            return Ok();
        }
    }
}
