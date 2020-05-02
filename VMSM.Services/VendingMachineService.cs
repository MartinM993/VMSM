using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly IRepository<VendingMachine> _repository;

        public VendingMachineService(IRepository<VendingMachine> repository)
        {
            _repository = repository;
        }

        public VendingMachine GetById(int id)
        {
            var vendingMachine = _repository.Get(id);

            return vendingMachine;
        }

        public IEnumerable<VendingMachine> GetByCriteria(VendingMachineSearchRequest request)
        {
            var vendingMachines = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Name))
                vendingMachines = vendingMachines.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Model))
                vendingMachines = vendingMachines.Where(x => x.Model.ToLower().Contains(request.Model.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Code))
                vendingMachines = vendingMachines.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));

            if (request.Category.HasValue)
                vendingMachines = vendingMachines.Where(x => x.Category == request.Category);

            return vendingMachines;
        }

        public VendingMachine Create(VendingMachine request)
        {
            var vendingMachine = _repository.Add(request);
            _repository.Save();

            return vendingMachine;
        }

        public VendingMachine Update(VendingMachine request)
        {
            var vendingMachine = _repository.Update(request);
            _repository.Save();

            return vendingMachine;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
