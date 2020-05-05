using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class VendingMachineProductPriceService : IVendingMachineProductPriceService
    {
        private readonly IRepository<VendingMachineProductPrice> _repository;

        public VendingMachineProductPriceService(IRepository<VendingMachineProductPrice> repository)
        {
            _repository = repository;
        }

        public VendingMachineProductPrice GetById(int id)
        {
            var vendingMachineProductPrice = _repository.Get(id);

            return vendingMachineProductPrice;
        }

        public IEnumerable<VendingMachineProductPrice> GetByCriteria(VendingMachineProductPriceSearchRequest request)
        {
            var vendingMachineProductPrices = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.ProductCode))
                vendingMachineProductPrices = vendingMachineProductPrices.Where(x => x.Product.Code.ToLower().Contains(request.ProductCode.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ProductName))
                vendingMachineProductPrices = vendingMachineProductPrices.Where(x => x.Product.Name.ToLower().Contains(request.ProductName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendingMachineCode))
                vendingMachineProductPrices = vendingMachineProductPrices.Where(x => x.VendingMachine.Code.ToLower().Contains(request.VendingMachineCode.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendingMachineName))
                vendingMachineProductPrices = vendingMachineProductPrices.Where(x => x.VendingMachine.Name.ToLower().Contains(request.VendingMachineName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendingMachineModel))
                vendingMachineProductPrices = vendingMachineProductPrices.Where(x => x.VendingMachine.Model.ToLower().Contains(request.VendingMachineModel.ToLower()));
            return vendingMachineProductPrices;
        }

        public VendingMachineProductPrice Create(VendingMachineProductPrice request)
        {
            var vendingMachineProductPrice = _repository.Add(request);
            _repository.Save();

            return vendingMachineProductPrice;
        }

        public VendingMachineProductPrice Update(VendingMachineProductPrice request)
        {
            var vendingMachineProductPrice = _repository.Update(request);
            _repository.Save();

            return vendingMachineProductPrice;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
