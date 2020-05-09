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
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService, UserManager<AppUser> userManager) : base(userManager)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        [Route(Routes.Schedule.ById)]
        public IActionResult GetById([FromRoute]int id)
        {
            var schedule = _scheduleService.GetById(id);

            return Ok(schedule);
        }

        [HttpGet]
        [Route(Routes.Schedule.Root)]
        public IActionResult GetByCriteria([FromQuery]ScheduleSearchRequest request)
        {
            var schedules = _scheduleService.GetByCriteria(request);

            return Ok(schedules);
        }

        [HttpPost]
        [Route(Routes.Schedule.Root)]
        public IActionResult Create([FromBody]Schedule request)
        {
            var schedule = new Schedule();
            request.SetAudit(CurrentLoggedUserId);

            if (ModelState.IsValid)
                schedule = _scheduleService.Create(request);

            return Ok(schedule.Id);
        }

        [HttpPut]
        [Route(Routes.Schedule.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody]Schedule request)
        {
            request.SetAudit(CurrentLoggedUserId);
            var schedule = _scheduleService.Update(request);

            return Ok(schedule.Id);
        }

        [HttpDelete]
        [Route(Routes.Schedule.ById)]
        public IActionResult Delete([FromRoute]int id)
        {
            _scheduleService.Delete(id);

            return Ok();
        }
    }
}
