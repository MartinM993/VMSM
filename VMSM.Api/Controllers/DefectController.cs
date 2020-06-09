using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DefectController : BaseController
    {
        private readonly IDefectService _defectService;
        private readonly IVendingMachineService _vendingMachineService;

        public DefectController(IDefectService defectService, IVendingMachineService vendingMachineService, UserManager<AppUser> userManager) : base(userManager)
        {
            _defectService = defectService;
            _vendingMachineService = vendingMachineService;
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
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Defect was successfull created!"
            };

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var defect = _defectService.Create(request);
                actionResult.EntityId = defect.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create defect was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            try
            {
                var vendingMachine = _vendingMachineService.GetById(request.VendingMachineId);
                vendingMachine.CostOfDefects += decimal.ToInt32(request.Cost);
                vendingMachine.NumberOfDefects += 1;
                _vendingMachineService.Update(vendingMachine);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create defect was successfully, but values for the vending machine was not updated properly, please contact the admin!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
