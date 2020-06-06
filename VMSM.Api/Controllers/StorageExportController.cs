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
    public class StorageExportController : BaseController
    {
        private readonly IStorageExportService _storageExportService;
        private readonly IProductService _productService;

        public StorageExportController(IStorageExportService storageExportService, IProductService productService, UserManager<AppUser> userManager) : base(userManager)
        {
            _storageExportService = storageExportService;
            _productService = productService;
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

            return Ok(actionResult);
        }
    }
}
