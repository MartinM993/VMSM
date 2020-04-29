using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route(Routes.Address.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var address = _addressService.GetById(id);

            return Ok(address);
        }

        [HttpGet]
        [Route(Routes.Address.Root)]
        public IActionResult GetByCriteria([FromQuery]SearchAddressRequest request)
        {
            var addresses = _addressService.GetByCriteria(request);

            return Ok(addresses);
        }

        [HttpPost]
        [Route(Routes.Address.Root)]
        public IActionResult Create([FromBody]Address request)
        {
            var address = new Address();

            if (ModelState.IsValid)
                address = _addressService.Create(request);

            return Ok(address.Id);
        }

        [HttpPut]
        [Route(Routes.Address.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]Address request)
        {
            var address = _addressService.Update(request);

            return Ok(address.Id);
        }

        [HttpDelete]
        [Route(Routes.Address.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _addressService.Delete(id);

            return Ok();
        }
    }
}
