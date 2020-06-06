using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VendingMachineController : BaseController
    {
        private readonly IVendingMachineService _vendingMachineService;

        public VendingMachineController(IVendingMachineService vendingMachineService, UserManager<AppUser> userManager) : base(userManager)
        {
            _vendingMachineService = vendingMachineService;
        }

        [HttpGet]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var actionResult = new CustomActionResultEntity<VendingMachine>
            {
                Successful = true
            };

            var vendingMachine = _vendingMachineService.GetById(id);

            if (vendingMachine == null)
            {
                actionResult.Successful = false;
                actionResult.Message = "Vending Machine do not exist!";

                return Ok(actionResult);
            }
            actionResult.Entity = vendingMachine;

            return Ok(actionResult);
        }

        [HttpGet]
        [Route(Routes.VendingMachine.Root)]
        public IActionResult GetByCriteria([FromQuery]VendingMachineSearchRequest request)
        {
            var vendingMachine = _vendingMachineService.GetByCriteria(request);

            return Ok(vendingMachine);
        }

        [HttpPost]
        [Route(Routes.VendingMachine.Root)]
        public IActionResult Create([FromBody]VendingMachine request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Vending Machine was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vendingMachine = _vendingMachineService.Create(request);
                actionResult.EntityId = vendingMachine.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create vending machine was unsuccessfully, please try again!";

                return Ok(actionResult);
            }          

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]VendingMachine request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Update vending machine informations was successfully!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vendingMachine = _vendingMachineService.Update(request);
                actionResult.EntityId = vendingMachine.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Update vending machine informations was unsuccessfully, please try again!";

                return Ok(actionResult);
            }          

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Delete vending machine was successfull!"
            };

            try
            {
                _vendingMachineService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Delete vending machine action failed, please try again!";

                return Ok(actionResult);
            }
            

            return Ok(actionResult);
        }
    }
}
