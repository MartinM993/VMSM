using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            var vendingMachineProduct = _repository.Get(id);
            var vendingMachineProducts = _repository.GetAll();
            vendingMachineProducts = vendingMachineProducts.Where(x => 
                                        x.VendingMachineId == vendingMachineProduct.VendingMachineId && 
                                        x.ProductId == vendingMachineProduct.ProductId && 
                                        x.Quantity == 0).ToList();

            foreach(var vmProduct in vendingMachineProducts)
            {
                _repository.Delete(vmProduct.Id);
                _repository.Save();
            }           
        }
    }
}
