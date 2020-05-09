using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using VMSM.Contracts.Entities;

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
                Int32.TryParse(_userManager.GetUserId(HttpContext.User), out int id);
                return id;
            }
        }
    }
}
