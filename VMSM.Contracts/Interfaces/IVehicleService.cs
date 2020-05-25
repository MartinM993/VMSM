using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IVehicleService
    {
        Vehicle GetById(int id);
        IEnumerable<Vehicle> GetByCriteria(VehicleSearchRequest request);
        IEnumerable<Vehicle> GetVehiclesWithoutUser(List<int?> userIds);
        Vehicle Create(Vehicle request);
        Vehicle Update(Vehicle request);
        void Delete(int id);
    }
}
