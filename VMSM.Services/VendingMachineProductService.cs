using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Services
{
    public class VendingMachineProductService : IVendingMachineProductService
    {
        private readonly IRepository<VendingMachineProduct> _repository;

        public VendingMachineProductService(IRepository<VendingMachineProduct> repository)
        {
            _repository = repository;
        }

        public VendingMachineProduct GetById(int id)
        {
            var defect = _repository.Get(id);

            return defect;
        }

        public IEnumerable<VendingMachineProduct> GetAll()
        {
            var defects = _repository.GetAll();

            return defects;
        }

        public VendingMachineProduct Create(VendingMachineProduct request)
        {
            var defect = _repository.Add(request);
            _repository.Save();

            return defect;
        }
    }
}
