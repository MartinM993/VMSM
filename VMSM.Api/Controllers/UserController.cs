using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, UserManager<AppUser> userManager) : base(userManager)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route(Routes.User.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var user = _userService.GetById(id);

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
            request.SetAudit(CurrentLoggedUserId);
            var user = _userService.Update(request);

            return Ok(user.Id);
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
