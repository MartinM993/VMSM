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
    public class IncomeController : BaseController
    {
        private readonly IIncomeService _incomeService;
        private readonly IVendingMachineService _vendingMachineService;

        public IncomeController(IIncomeService incomeService, IVendingMachineService vendingMachineService, UserManager<AppUser> userManager) : base(userManager)
        {
            _incomeService = incomeService;
            _vendingMachineService = vendingMachineService;
        }

        [HttpGet]
        [Route(Routes.Income.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var income = _incomeService.GetById(id);

            return Ok(income);
        }

        [HttpGet]
        [Route(Routes.Income.Root)]
        public IActionResult GetByCriteria([FromQuery]IncomeSearchRequest request)
        {
            var incomes = _incomeService.GetByCriteria(request);

            return Ok(incomes);
        }

        [HttpPost]
        [Route(Routes.Income.Root)]
        public IActionResult Create([FromBody]Income request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Income was successfull created!"
            };          

            try
            {
                request.SetAudit(CurrentLoggedUserId);
                var income = _incomeService.Create(request);
                actionResult.EntityId = income.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create income was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            try
            {
                var vendingMachine = _vendingMachineService.GetById(request.VendingMachineId);
                vendingMachine.Income += request.CollectedIncome;
                _vendingMachineService.Update(vendingMachine);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create income was successfully, but Income value for the vending machine was not updated properly, please contact the admin!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }
    }
}
