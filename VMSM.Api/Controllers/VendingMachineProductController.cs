using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class VendingMachineProductController : ControllerBase
    {
        private readonly IVendingMachineProductService _vendingMachineProductService;

        public VendingMachineProductController(IVendingMachineProductService vendingMachineProductService)
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
            var vendingMachineProduct = new VendingMachineProduct();

            if (ModelState.IsValid)
                vendingMachineProduct = _vendingMachineProductService.Create(request);

            return Ok(vendingMachineProduct.Id);
        }
    }
}
