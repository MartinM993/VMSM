using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Enums;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VendingMachineProductController : BaseController
    {
        private readonly IVendingMachineProductService _vendingMachineProductService;
        private readonly IProductService _productService;
        private readonly IFieldWorkerProductService _fieldWorkerProductService;

        public VendingMachineProductController(IVendingMachineProductService vendingMachineProductService,
                                               IProductService productService,
                                               IFieldWorkerProductService fieldWorkerProductService,
                                               UserManager<AppUser> userManager) : base(userManager)
        {
            _vendingMachineProductService = vendingMachineProductService;
            _productService = productService;
            _fieldWorkerProductService = fieldWorkerProductService;
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
            var userId = CurrentLoggedUserId;

            try
            {
                request.SetAudit(userId);
                var vendingMachineProduct = _vendingMachineProductService.Create(request);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Product was unsuccessfull added for Vending Machine, please try again!";

                return Ok(actionResult);
            }

            if(CurrentLoggedUserRole == Role.FieldWorker)
            {
                var product = _productService.GetById(request.ProductId);
                var fieldWorkerProducts = _fieldWorkerProductService.GetByCriteria(new FieldWorkerProductSearchRequest
                {
                    FieldWorkerId = CurrentLoggedUserId,
                    ProductId = request.ProductId
                });
                var fieldWorkerProduct = fieldWorkerProducts.FirstOrDefault();
                try
                {
                    product.Quantity -= request.Quantity;
                    product.SetAudit(userId);
                    _productService.Update(product);
                }
                catch
                {
                    actionResult.Successful = false;
                    actionResult.Message = "Product was successfully added for Vending Machine, but Quantity for product was not updated, contact your superior!";

                    return Ok(actionResult);
                }

                if (fieldWorkerProduct == null)
                {
                    actionResult.Successful = false;
                    actionResult.Message = "Product was successfully added for Vending Machine, but field worker should not possess these product, contact your superior!";

                    return Ok(actionResult);
                }
                else
                {
                    try
                    {
                        fieldWorkerProduct.Quantity -= request.Quantity;
                        fieldWorkerProduct.SetAudit(userId);
                        _fieldWorkerProductService.Update(fieldWorkerProduct);
                    }
                    catch
                    {
                        actionResult.Successful = false;
                        actionResult.Message = "Product was successfully added for Vending Machine, but Quantity for field worker product was not updated, contact your superior!";

                        return Ok(actionResult);
                    }
                }
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
