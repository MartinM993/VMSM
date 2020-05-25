using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
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
            var vehicle = new Vehicle();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                vehicle = _vehicleService.Create(request);

            return Ok(vehicle.Id);
        }

        [HttpPut]
        [Route(Routes.Vehicle.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]Vehicle request)
        {
            request.SetAudit(CurrentLoggedUserId);
            var vehicle = _vehicleService.Update(request);

            return Ok(vehicle.Id);
        }

        [HttpDelete]
        [Route(Routes.Vehicle.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _vehicleService.Delete(id);

            return Ok();
        }
    }
}
