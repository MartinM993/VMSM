using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;
using VMSM.Data;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        protected readonly VMSMDbContext _context;

        public ProductController(IProductService productService, UserManager<AppUser> userManager, VMSMDbContext context) : base(userManager)
        {
            _productService = productService;
            this._context = context;
        }

        [HttpGet]
        [Route(Routes.Product.ById)]
        public IActionResult GetById([FromRoute] int id)
        {
            var actionResult = new CustomActionResultEntity<Product>
            {
                Successful = true
            };

            var product = _productService.GetById(id);

            if (product == null)
            {
                actionResult.Successful = false;
                actionResult.Message = "Product do not exist!";

                return Ok(actionResult);
            }
            actionResult.Entity = product;

            return Ok(actionResult);
        }

        [HttpGet]
        [Route(Routes.Product.Root)]
        public IActionResult GetByCriteria([FromQuery] ProductSearchRequest request)
        {
            var products = _productService.GetByCriteria(request);

            return Ok(products);
        }

        [HttpPost]
        [Route(Routes.Product.Root)]
        public IActionResult Create([FromBody] Product request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Product was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                request.PreviousPurchasePrice = request.PurchasePrice;
                var product = _productService.Create(request);
                actionResult.EntityId = product.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create product was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.Product.ById)]
        public IActionResult Update([FromRoute] int id, [FromBody] Product request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Update product was successfully!"
            };

            var dbproduct = _productService.GetById(request.Id);

            if (request.PurchasePrice != dbproduct.PurchasePrice)
            {
                request.PreviousPurchasePrice = dbproduct.PurchasePrice;
            }

            if (dbproduct.Quantity > request.Quantity)
            {
                actionResult.Successful = false;
                actionResult.Message = $"Quantity can not have value lower than current value in data base! Please enter value larger than {dbproduct.Quantity} ";

                return Ok(actionResult);
            }

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                _context.Entry(request).State = EntityState.Deleted;
                var product = _productService.Update(request);

                actionResult.EntityId = product.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Update product was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete]
        [Route(Routes.Product.ById)]
        public IActionResult Delete([FromRoute] int id)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Delete product was successfull!"
            };

            try
            {
                _productService.Delete(id);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Delete product action failed, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
