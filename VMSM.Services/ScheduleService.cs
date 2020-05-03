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
            var address = _repository.Get(id);

            return address;
        }

        public IEnumerable<Schedule> GetByCriteria(ScheduleSearchRequest request)
        {
            var addresses = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerLastName))
                addresses = addresses.Where(x => x.FieldWorker.Name.ToLower().Contains(request.FieldWorkerLastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerLastName))
                addresses = addresses.Where(x => x.FieldWorker.LastName.ToLower().Contains(request.FieldWorkerLastName.ToLower()));

            if (request.Day.HasValue)
                addresses = addresses.Where(x => x.Day == request.Day);

            return addresses;
        }

        public Schedule Create(Schedule request)
        {
            var address = _repository.Add(request);
            _repository.Save();

            return address;
        }

        public Schedule Update(Schedule request)
        {
            var address = _repository.Update(request);
            _repository.Save();

            return address;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
