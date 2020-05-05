using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IVendingMachineProductPriceService
    {
        VendingMachineProductPrice GetById(int id);
        IEnumerable<VendingMachineProductPrice> GetByCriteria(VendingMachineProductPriceSearchRequest request);
        VendingMachineProductPrice Create(VendingMachineProductPrice request);
        VendingMachineProductPrice Update(VendingMachineProductPrice request);
        void Delete(int id);
    }
}
