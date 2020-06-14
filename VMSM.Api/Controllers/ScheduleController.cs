using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Models;
using VMSM.Contracts.Requests;

namespace VMSM.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public IActionResult Create([FromBody] ScheduleCreateOrEtitRequest request)
        {
            var schedule = new Schedule();
            schedule.Day = request.Day;
            schedule.FieldWorkerId = request.FieldWorkerId;
            schedule.SetAudit(CurrentLoggedUserId);

            var vendingMachineSchedules = new List<VendingMachineSchedule>();
            foreach (var id in request.VendingMachineIds)
            {
                var vendingMachineSchedule = new VendingMachineSchedule
                {
                    VendingMachineId = id
                };
                vendingMachineSchedule.SetAudit(CurrentLoggedUserId);
                vendingMachineSchedules.Add(vendingMachineSchedule);
            }

            schedule.VendingMachineSchedules = vendingMachineSchedules;

            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Schedule was successfull created!"
            };

            try
            {
                var dbSchedule = _scheduleService.Create(schedule);
                actionResult.EntityId = dbSchedule.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Create schedule was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.Schedule.ById)]
        public IActionResult Update([FromRoute]int id, [FromBody] ScheduleCreateOrEtitRequest request)
        {
            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Schedule was successfull updated!"
            };

            var scheduleId = request.ScheduleId ?? 0;
            var schedule = new Schedule();
            if (request.ScheduleId.HasValue)
            {
                schedule = _scheduleService.GetById(scheduleId);
            }
            else
            {
                actionResult.Successful = false;
                actionResult.Message = "Selected Schedule can not be found!";
            }

            foreach (var vendingMachineId in request.VendingMachineIds)
            {
                var vendingMachineSchedule = new VendingMachineSchedule
                {
                    VendingMachineId = vendingMachineId
                };
                vendingMachineSchedule.SetAudit(CurrentLoggedUserId);
                schedule.VendingMachineSchedules.Add(vendingMachineSchedule);
            }

            try
            {
                var dbSchedule = _scheduleService.Update(schedule);
                actionResult.EntityId = dbSchedule.Id;
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Update schedule was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPut]
        [Route(Routes.Schedule.RemoveVM)]
        public IActionResult RemoveVendingMachineSchedule([FromRoute] int id, [FromBody] VendingMachineSchedule request)
        {
            var scheduleId = request.ScheduleId ?? 0;

            var schedule = _scheduleService.GetById(scheduleId);
            var vendingMachineSchedules = schedule.VendingMachineSchedules.ToList();
            vendingMachineSchedules.RemoveAll(x => x.ScheduleId == request.ScheduleId && x.VendingMachineId == request.VendingMachineId);
            schedule.VendingMachineSchedules = vendingMachineSchedules;

            var actionResult = new CustomActionResult
            {
                Successful = true,
                Message = "Remove Vending Machine from Schedule was successfully!"
            };

            try
            {
                schedule.SetAudit(CurrentLoggedUserId);
                var dbSchedule = _scheduleService.Update(schedule);
            }
            catch
            {
                actionResult.Successful = false;
                actionResult.Message = "Remove Vending Machine from Schedule was unsuccessfully, please try again!";

                return Ok(actionResult);
            }

            return Ok(actionResult);
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
