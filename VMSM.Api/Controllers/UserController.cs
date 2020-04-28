using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route(Routes.User.ById)]
        public IActionResult GetUserById([FromRoute]int id)
        {
            var user = _userService.GetUserById(id);

            return Ok(user);
        }

        [HttpGet]
        [Route(Routes.User.Root)]
        public IActionResult GetUsers([FromQuery]SearchUserRequest request)
        {
            var users = _userService.GetUsers(request);

            return Ok(users);
        }

        [HttpPost]
        [Route(Routes.User.Root)]
        public IActionResult CreateUser([FromBody]User request)
        {
            var user = new User();

            if (ModelState.IsValid)
                user = _userService.CreateUser(request);

            return Ok(user.Id);
        }

        [HttpPut]
        [Route(Routes.User.ById)]
        public IActionResult UpdateUser([FromRoute]int id, [FromBody]User request)
        {
            var user = _userService.UpdateUser(request);

            return Ok(user.Id);
        }

        [HttpDelete]
        [Route(Routes.User.ById)]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            _userService.DeleteUser(id);

            return Ok();
        }
    }
}
