using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class StorageImportController : ControllerBase
    {
        private readonly IStorageImportService _storageImportService;

        public StorageImportController(IStorageImportService storageImportService)
        {
            _storageImportService = storageImportService;
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
            var storageImport = new StorageImport();

            if (ModelState.IsValid)
                storageImport = _storageImportService.Create(request);

            return Ok(storageImport.Id);
        }
    }
}
