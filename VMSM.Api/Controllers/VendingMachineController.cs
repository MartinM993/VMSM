using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        private readonly IVendingMachineService _vendingMachineService;

        public VendingMachineController(IVendingMachineService vendingMachineService)
        {
            _vendingMachineService = vendingMachineService;
        }

        [HttpGet]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var vendingMachine = _vendingMachineService.GetById(id);

            return Ok(vendingMachine);
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
            var vendingMachine = new VendingMachine();

            if (ModelState.IsValid)
                vendingMachine = _vendingMachineService.Create(request);

            return Ok(vendingMachine.Id);
        }

        [HttpPut]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]VendingMachine request)
        {
            var vendingMachine = _vendingMachineService.Update(request);

            return Ok(vendingMachine.Id);
        }

        [HttpDelete]
        [Route(Routes.VendingMachine.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _vendingMachineService.Delete(id);

            return Ok();
        }
    }
}
