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
    public class VendingMachineProductPriceController : BaseController
    {
        private readonly IVendingMachineProductPriceService _vendingMachineProductPriceService;

        public VendingMachineProductPriceController(IVendingMachineProductPriceService vendingMachineProductPriceService, UserManager<AppUser> userManager) : base(userManager)
        {
            _vendingMachineProductPriceService = vendingMachineProductPriceService;
        }

        [HttpGet]
        [Route(Routes.VendingMachineProductPrice.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var vendingMachineProductPrice = _vendingMachineProductPriceService.GetById(id);

            return Ok(vendingMachineProductPrice);
        }

        [HttpGet]
        [Route(Routes.VendingMachineProductPrice.Root)]
        public IActionResult GetByCriteria([FromQuery]VendingMachineProductPriceSearchRequest request)
        {
            var vendingMachineProductPrices = _vendingMachineProductPriceService.GetByCriteria(request);

            return Ok(vendingMachineProductPrices);
        }

        [HttpPost]
        [Route(Routes.VendingMachineProductPrice.Root)]
        public IActionResult Create([FromBody]VendingMachineProductPrice request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Product price was successfull added for Vending Machine!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vendingMachineProductPrice = _vendingMachineProductPriceService.Create(request);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Product price was unsuccessfull added for Vending Machine, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.VendingMachineProductPrice.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]VendingMachineProductPrice request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Product price was successfull updated for Vending Machine!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vendingMachineProductPrice = _vendingMachineProductPriceService.Update(request);
                actionResult.EntityId = vendingMachineProductPrice.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Product price was unsuccessfull updated for Vending Machine, please try again!!";

                return Ok(actionResult);
            }

            

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.VendingMachineProductPrice.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Remove product price from vending machine was successfull!"
            };

            try
            {
                _vendingMachineProductPriceService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Remove product price from vending machine action failed, please try again!";

                return Ok(actionResult);
            }
            

            return Ok(actionResult);
        }
    }
}
