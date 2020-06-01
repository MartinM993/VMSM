using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(IUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route(Routes.User.ById)]
        public IActionResult GetById([FromRoute] int id)
        {
            var actionResult = new CustomActionResultEntity<AppUser>
            {
                Successful = true
            };

            var user = _userService.GetById(id);

            if(user == null)
            {
                actionResult.Successful = false;
                actionResult.Message = "User do not exist!";

                return Ok(actionResult);
            }
            actionResult.Entity = user;

            return Ok(actionResult);
        }

        [HttpGet]
        [Route(Routes.User.CurrentLoggedUser)]
        public IActionResult GetCurrentLoggedUser()
        {
            var user = _userService.GetById(CurrentLoggedUserId);

            return Ok(user);
        }

        [HttpGet]
        [Route(Routes.User.Root)]
        public IActionResult GetByCriteria([FromQuery] UserSearchRequest request)
        {
            var users = _userService.GetByCriteria(request);

            return Ok(users);
        }

        [HttpPost]
        [Route(Routes.User.Root)]
        public IActionResult Create([FromBody] User request)
        {
            var appUser = new AppUser
            {
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserRole = request.Role,
                AddressId = request.AddressId,
                VehicleId = request.VehicleId,
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper()
            };

            var result = _userManager.CreateAsync(appUser, request.Password).Result;
            var roleResult = _userManager.AddToRoleAsync(appUser, appUser.UserRole.ToString()).Result;

            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "User was successfull created!"
            };

            if (!result.Succeeded)
            {
                actionResult.Successful = false;
                actionResult.Message = "Create user action failed, please try again!";
            }

            if (!roleResult.Succeeded)
            {
                actionResult.Successful = false;
                actionResult.Message += "But Role was not added, please try to update the user!";
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.User.ById)]
        public IActionResult Update([FromRoute] int id, [FromBody] AppUser request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Update user was successfull!"
            };

            request.NormalizedEmail = request.Email.Trim().ToUpper();
            request.UserName = request.Email.Trim();
            request.NormalizedUserName = request.Email.Trim().ToUpper();

            var dbUser = _userService.GetById(request.Id);

            if (dbUser == null)
            {
                actionResult.Successful = false;
                actionResult.Message = "User do not exist!";

                return Ok(actionResult);
            }

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var user = _userService.Update(request);
                _signInManager.RefreshSignInAsync(user);
                actionResult.EntityId = user.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Update user action failed, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.User.ChangeRole)]
        public IActionResult ChangeRole([FromBody] int id)
        {
            var user = _userService.GetById(id);
            var isInRole = _userManager.IsInRoleAsync(user, user.UserRole.ToString()).Result;
            if (!isInRole)
            {
                var q = _userManager.GetRolesAsync(user).Result;
                var removeFromRolesResult = _userManager.RemoveFromRolesAsync(user, q).Result;
                var addToRoleResult = _userManager.AddToRoleAsync(user, user.UserRole.ToString()).Result;
            }
            
            return Ok();
        }

        [HttpDelete]
        [Route(Routes.User.ById)]
        public IActionResult Delete([FromRoute] int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Delete user was successfull!"
            };

            try
            {
                _userService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Delete user action failed, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.User.Root)]
        public IActionResult Delete([FromBody]AppUser request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Delete user was successfull!"
            };

            try
            {
                _userService.Delete(request);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Delete user action failed, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
