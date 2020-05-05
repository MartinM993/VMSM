using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class StorageExportController : ControllerBase
    {
        private readonly IStorageExportService _storageExportService;

        public StorageExportController(IStorageExportService storageExportService)
        {
            _storageExportService = storageExportService;
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
            var storageExport = new StorageExport();

            if (ModelState.IsValid)
                storageExport = _storageExportService.Create(request);

            return Ok(storageExport.Id);
        }
    }
}
