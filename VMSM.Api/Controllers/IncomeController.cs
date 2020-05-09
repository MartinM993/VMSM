using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    public class IncomeController : BaseController
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService, UserManager<AppUser> userManager) : base(userManager)
        {
            _incomeService = incomeService;
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
            var income = new Income();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                income = _incomeService.Create(request);

            return Ok(income.Id);
        }
    }
}
