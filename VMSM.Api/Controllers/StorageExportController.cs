using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StorageExportController : BaseController
    {
        private readonly IStorageExportService _storageExportService;
        private readonly IProductService _productService;
        private readonly IFieldWorkerProductService _fieldWorkerProductService;

        public StorageExportController(IStorageExportService storageExportService, 
                                       IProductService productService, 
                                       IFieldWorkerProductService fieldWorkerProductService, 
                                       UserManager<AppUser> userManager) : base(userManager)
        {
            _storageExportService = storageExportService;
            _productService = productService;
            _fieldWorkerProductService = fieldWorkerProductService;
        }

        [HttpGet]
        [Route(Routes.StorageExport.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var storageExport = _storageExportService.GetById(id);

            return Ok(storageExport);
        }

        [HttpGet]
        [Route(Routes.StorageExport.Root)]
        public IActionResult GetByCriteria([FromQuery]StorageExportSearchRequest request)
        {
            var storageExports = _storageExportService.GetByCriteria(request);

            return Ok(storageExports);
        }

        [HttpPost]
        [Route(Routes.StorageExport.Root)]
        public IActionResult Create([FromBody]StorageExport request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Storage Export was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var storageExport = _storageExportService.Create(request);
                actionResult.EntityId = storageExport.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create storage export was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            try
            {
                var product = _productService.GetById(request.ProductId);
                product.StorageQuantity -= request.Quantity;
                _productService.Update(product);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create storage export was successfully, but Storage Quantity of the product was not updated properly, please contact Office worker!";

                return Ok(actionResult);
            }

            var fieldWorkerProducts = _fieldWorkerProductService.GetByCriteria(new FieldWorkerProductSearchRequest 
            { 
                FieldWorkerId = request.FieldWorkerId,
                ProductId = request.ProductId
            });

            try
            {
                if (fieldWorkerProducts.Count() == 0)
                {
                    var fieldWorkerProduct = new FieldWorkerProduct
                    {
                        FieldWorkerId = request.FieldWorkerId,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    };
                    fieldWorkerProduct.SetAudit(CurrentLoggedUserId);

                    _fieldWorkerProductService.Create(fieldWorkerProduct);
                }
                else
                {
                    var fieldWorkerProduct = fieldWorkerProducts.First();
                    fieldWorkerProduct.Quantity += request.Quantity;
                    fieldWorkerProduct.SetAudit(CurrentLoggedUserId);

                    _fieldWorkerProductService.Update(fieldWorkerProduct);
                }
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create storage export was successfully, but Field Worker Quantity of the product was not updated properly, please contact Office worker!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
