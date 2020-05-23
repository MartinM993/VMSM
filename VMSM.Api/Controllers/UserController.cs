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
        public IActionResult GetById([FromRoute]int id)
        {   
            var user = _userService.GetById(id);

            return Ok(user);
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
        public IActionResult GetByCriteria([FromQuery]UserSearchRequest request)
        {
            var users = _userService.GetByCriteria(request);

            return Ok(users);
        }

        [HttpPost]
        [Route(Routes.User.Root)]
        public IActionResult Create([FromBody]AppUser request)
        {
            request.UserName = request.Email;
            request.NormalizedEmail = request.Email.ToUpper();
            request.NormalizedUserName = request.Email.ToUpper();
            request.SetAudit(CurrentLoggedUserId);

            var result = _userManager.CreateAsync(request, "test123").Result;
            var roleResult = _userManager.AddToRoleAsync(request, request.UserRole.ToString()).Result;

            return Ok();
        }

        [HttpPut]
        [Route(Routes.User.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]AppUser request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Update user information was successfully!"
            };

            request.NormalizedEmail = request.Email.Trim().ToUpper();
            request.UserName = request.Email.Trim().ToUpper();
            request.NormalizedUserName = request.Email.Trim().ToUpper();

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
                actionResult.Message = "Update user information was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.User.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}
