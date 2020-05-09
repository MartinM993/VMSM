using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class FieldWorkerProductController : BaseController
    {
        private readonly IFieldWorkerProductService _fieldWorkerProductService;

        public FieldWorkerProductController(IFieldWorkerProductService fieldWorkerProductService, UserManager<AppUser> userManager) : base(userManager)
        {
            _fieldWorkerProductService = fieldWorkerProductService;
        }

        [HttpGet]
        [Route(Routes.FieldWorkerProduct.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var fieldWorkerProduct = _fieldWorkerProductService.GetById(id);

            return Ok(fieldWorkerProduct);
        }

        [HttpPost]
        [Route(Routes.FieldWorkerProduct.Root)]
        public IActionResult Create([FromBody]FieldWorkerProduct request)
        {
            var fieldWorkerProduct = new FieldWorkerProduct();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                fieldWorkerProduct = _fieldWorkerProductService.Create(request);

            return Ok(fieldWorkerProduct.Id);
        }

        [HttpPut]
        [Route(Routes.FieldWorkerProduct.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]FieldWorkerProduct request)
        {
            request.SetAudit(CurrentLoggedUserId);
            var fieldWorkerProduct = _fieldWorkerProductService.Update(request);

            return Ok(fieldWorkerProduct.Id);
        }

        [HttpDelete]
        [Route(Routes.FieldWorkerProduct.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _fieldWorkerProductService.Delete(id);

            return Ok();
        }
    }
}
