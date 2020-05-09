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
            var vendingMachineProductPrice = new VendingMachineProductPrice();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                vendingMachineProductPrice = _vendingMachineProductPriceService.Create(request);

            return Ok(vendingMachineProductPrice.Id);
        }

        [HttpPut]
        [Route(Routes.VendingMachineProductPrice.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]VendingMachineProductPrice request)
        {
            request.SetAudit(CurrentLoggedUserId);
            var vendingMachineProductPrice = _vendingMachineProductPriceService.Update(request);

            return Ok(vendingMachineProductPrice.Id);
        }

        [HttpDelete]
        [Route(Routes.VendingMachineProductPrice.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _vendingMachineProductPriceService.Delete(id);

            return Ok();
        }
    }
}
