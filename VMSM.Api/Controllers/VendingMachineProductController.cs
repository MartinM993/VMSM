using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VendingMachineProductController : BaseController
    {
        private readonly IVendingMachineProductService _vendingMachineProductService;

        public VendingMachineProductController(IVendingMachineProductService vendingMachineProductService, UserManager<AppUser> userManager) : base(userManager)
        {
            _vendingMachineProductService = vendingMachineProductService;
        }

        [HttpGet]
        [Route(Routes.VendingMachineProduct.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var vendingMachineProduct = _vendingMachineProductService.GetById(id);

            return Ok(vendingMachineProduct);
        }

        [HttpGet]
        [Route(Routes.VendingMachineProduct.Root)]
        public IActionResult GetByAll()
        {
            var vendingMachineProducts = _vendingMachineProductService.GetAll();

            return Ok(vendingMachineProducts);
        }

        [HttpPost]
        [Route(Routes.VendingMachineProduct.Root)]
        public IActionResult Create([FromBody]VendingMachineProduct request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Product was successfull added for Vending Machine!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var vendingMachineProduct = _vendingMachineProductService.Create(request);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Product was unsuccessfull added for Vending Machine, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.VendingMachineProduct.ById)]
        public IActionResult Delete([FromRoute] int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Remove product from vending machine was successfull!"
            };

            try
            {
                _vendingMachineProductService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Remove product from vending machine action failed, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
