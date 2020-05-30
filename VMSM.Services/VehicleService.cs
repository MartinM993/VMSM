using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _repository;

        public VehicleService(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public Vehicle GetById(int id)
        {
            var vehicle = _repository.Get(id);

            return vehicle;
        }

        public IEnumerable<Vehicle> GetByCriteria(VehicleSearchRequest request)
        {
            var vehicles = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Code))
                vehicles = vehicles.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Model))
                vehicles = vehicles.Where(x => x.Model.ToLower().Contains(request.Model.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Brand))
                vehicles = vehicles.Where(x => x.Brand.ToLower().Contains(request.Brand.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.RegistrationPlate))
                vehicles = vehicles.Where(x => x.RegistrationPlate.ToLower().Contains(request.RegistrationPlate.ToLower()));

            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclesWithoutUser(List<int?> vehicleIds)
        {
            var vehicles = _repository.GetAll();
            
            if (vehicleIds.Any())
            {
                vehicles = vehicles.ToList().Where(x => !vehicleIds.Contains(x.Id));
            }

            return vehicles;
        }

        public Vehicle Create(Vehicle request)
        {
            var vehicle = _repository.Add(request);
            _repository.Save();

            return vehicle;
        }

        public Vehicle Update(Vehicle request)
        {
            var vehicle = _repository.Update(request);
            _repository.Save();

            return vehicle;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
