using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Enums;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService, UserManager<AppUser> userManager) : base(userManager)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route(Routes.Report.Root)]
        public IActionResult GetByCriteria([FromQuery] ReportRequest request)
        {

            switch (request.Type)
            {
                case ReportType.Income:
                    {
                        _reportService.IncomeReport(request);
                        return Ok();
                    }
                case ReportType.Defect:
                    {
                        var defects = _reportService.DefectReport(request);
                        return Ok(defects);
                    }
            }

            return Ok();
        }
    }
}
