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
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, UserManager<AppUser> userManager) : base(userManager)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route(Routes.Product.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var product = _productService.GetById(id);

            return Ok(product);
        }

        [HttpGet]
        [Route(Routes.Product.Root)]
        public IActionResult GetByCriteria([FromQuery]ProductSearchRequest request)
        {
            var products = _productService.GetByCriteria(request);

            return Ok(products);
        }

        [HttpPost]
        [Route(Routes.Product.Root)]
        public IActionResult Create([FromBody]Product request)
        {
            var product = new Product();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                product = _productService.Create(request);

            return Ok(product.Id);
        }

        [HttpPut]
        [Route(Routes.Product.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]Product request)
        {
            request.SetAudit(CurrentLoggedUserId);
            var product = _productService.Update(request);

            return Ok(product.Id);
        }

        [HttpDelete]
        [Route(Routes.Product.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
