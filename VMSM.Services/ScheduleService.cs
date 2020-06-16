using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _repository;

        public ScheduleService(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public Schedule GetById(int id)
        {
            var schedule = _repository.Get(id);

            return schedule;
        }

        public IEnumerable<Schedule> GetByCriteria(ScheduleSearchRequest request)
        {
            var schedules = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerLastName))
                schedules = schedules.Where(x => x.FieldWorker.Name.ToLower().Contains(request.FieldWorkerLastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerName))
                schedules = schedules.Where(x => x.FieldWorker.LastName.ToLower().Contains(request.FieldWorkerName.ToLower()));

            if (request.Day.HasValue)
                schedules = schedules.Where(x => x.Day == request.Day);

            if (request.FieldWorkerId.HasValue)
                schedules = schedules.Where(x => x.FieldWorkerId == request.FieldWorkerId);

            return schedules;
        }

        public Schedule Create(Schedule request)
        {
            var schedule = _repository.Add(request);
            _repository.Save();

            return schedule;
        }

        public Schedule Update(Schedule request)
        {
            var schedule = _repository.Update(request);
            _repository.Save();

            return schedule;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
