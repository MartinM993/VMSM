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
        public IActionResult Create([FromBody]User request)
        {
            var user = new User();

            if (ModelState.IsValid)
                user = _userService.Create(request);

            return Ok(user.Id);
        }

        [HttpPut]
        [Route(Routes.User.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]User request)
        {
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
