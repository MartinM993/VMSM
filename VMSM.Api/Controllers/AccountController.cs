using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VMSM.Client;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IConfiguration configuration, IUserService userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpPost]
        [Route(Routes.Account.Login)]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            var loginResult = new CustomActionResult();

            if (!result.Succeeded)
            {
                loginResult.Successful = false;
                loginResult.Message = "Invalid username or password!";

                return Ok(loginResult);
            }

            var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, request.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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
        [Route(Routes.Account.Logout)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        [HttpPost]
        [Route(Routes.Account.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword request)
        {
            var user = _userService.GetById(CurrentLoggedUserId);
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Password was successfully changed!"
            };

            if (!result.Succeeded)
            {
                actionResult.Successful = false;
                actionResult.Message = "Change Password action failed, please try again!";

                return Ok(actionResult);
            }

            await _signInManager.RefreshSignInAsync(user);

            return Ok(actionResult);
        }
    }
}
