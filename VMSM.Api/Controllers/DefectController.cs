using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class DefectController : ControllerBase
    {
        private readonly IDefectService _defectService;

        public DefectController(IDefectService defectService)
        {
            _defectService = defectService;
        }

        [HttpGet]
        [Route(Routes.Defect.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var defect = _defectService.GetById(id);

            return Ok(defect);
        }

        [HttpGet]
        [Route(Routes.Defect.Root)]
        public IActionResult GetByCriteria()
        {
            var defects = _defectService.GetAll();

            return Ok(defects);
        }

        [HttpPost]
        [Route(Routes.Defect.Root)]
        public IActionResult Create([FromBody]Defect request)
        {
            var defect = new Defect();

            if (ModelState.IsValid)
                defect = _defectService.Create(request);

            return Ok(defect.Id);
        }
    }
}
