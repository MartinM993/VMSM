using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IScheduleService
    {
        Schedule GetById(int id);
        IEnumerable<Schedule> GetByCriteria(ScheduleSearchRequest request);
        Schedule Create(Schedule request);
        Schedule Update(Schedule request);
        void Delete(int id);
    }
}
