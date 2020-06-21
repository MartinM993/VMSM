using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Enums;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly UserManager<AppUser> _userManager;

        public BaseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected int CurrentLoggedUserId
        {
            get
            {
                var currentLoggedUser = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                return currentLoggedUser.Id;
            }
        }

        protected Role CurrentLoggedUserRole
        {
            get
            {
                var currentLoggedUser = _userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                return currentLoggedUser.UserRole;
            }
        }
    }
}
