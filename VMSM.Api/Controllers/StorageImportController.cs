using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StorageImportController : BaseController
    {
        private readonly IStorageImportService _storageImportService;
        private readonly IProductService _productService;

        public StorageImportController(IStorageImportService storageImportService, IProductService productService, UserManager<AppUser> userManager) : base(userManager)
        {
            _storageImportService = storageImportService;
            _productService = productService;
        }

        [HttpGet]
        [Route(Routes.StorageImport.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var storageImport = _storageImportService.GetById(id);

            return Ok(storageImport);
        }

        [HttpGet]
        [Route(Routes.StorageImport.Root)]
        public IActionResult GetByCriteria([FromQuery]StorageImportSearchRequest request)
        {
            var storageImports = _storageImportService.GetByCriteria(request);

            return Ok(storageImports);
        }

        [HttpPost]
        [Route(Routes.StorageImport.Root)]
        public IActionResult Create([FromBody]StorageImport request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Storage Import was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var storageImport = _storageImportService.Create(request);
                actionResult.EntityId = storageImport.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create storage import was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            try
            {
                var product = _productService.GetById(request.ProductId);
                product.StorageQuantity += request.Quantity;
                product.SetAudit(CurrentLoggedUserId);
                _productService.Update(product);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create storage import was successfully, but Storage Quantity of the product was not updated properly, please contact Office worker!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
