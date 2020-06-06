using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;

        public VehicleController(IVehicleService vehicleService, IUserService userService, UserManager<AppUser> userManager) : base(userManager)
        {
            _vehicleService = vehicleService;
            _userService = userService;
        }

        [HttpGet]
        [Route(Routes.Vehicle.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var vehicle = _vehicleService.GetById(id);

            return Ok(vehicle);
        }

        [HttpGet]
        [Route(Routes.Vehicle.Root)]
        public IActionResult GetByCriteria([FromQuery]VehicleSearchRequest request)
        {
            var vehicles = _vehicleService.GetByCriteria(request);

            return Ok(vehicles);
        }

        [HttpGet]
        [Route(Routes.Vehicle.WithoutUser)]
        public IActionResult WithoutUser()
        {
            var vehicleIds = _userService.GetByCriteria(new UserSearchRequest()).Where(x => x.VehicleId != null).Select(x => x.VehicleId).ToList();
            var vehicles = _vehicleService.GetVehiclesWithoutUser(vehicleIds);

            return Ok(vehicles);
        }

        [HttpPost]
        [Route(Routes.Vehicle.Root)]
        public IActionResult Create([FromBody]Vehicle request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Vehicle was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vehicle = _vehicleService.Create(request);
                actionResult.EntityId = vehicle.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create vehicle was unsuccessfully, please try again!";

                return Ok(actionResult);
            }
            

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.Vehicle.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]Vehicle request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Update vehicle information was successfully!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vehicle = _vehicleService.Update(request);
                actionResult.EntityId = vehicle.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Update vehicle information was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.Vehicle.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Delete vehicle was successfull!"
            };

            try
            {
                _vehicleService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Delete vehicle action failed, please try again!";

                return Ok(actionResult);
            }     

            return Ok(actionResult);
        }
    }
}
