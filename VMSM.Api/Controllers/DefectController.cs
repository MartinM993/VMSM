using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class DefectController : BaseController
    {
        private readonly IDefectService _defectService;

        public DefectController(IDefectService defectService, UserManager<AppUser> userManager) : base(userManager)
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
        public IActionResult GetByAll()
        {
            var defects = _defectService.GetAll();

            return Ok(defects);
        }

        [HttpPost]
        [Route(Routes.Defect.Root)]
        public IActionResult Create([FromBody]Defect request)
        {
            var defect = new Defect();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                defect = _defectService.Create(request);

            return Ok(defect.Id);
        }
    }
}
