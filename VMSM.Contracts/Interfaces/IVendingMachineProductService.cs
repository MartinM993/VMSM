using System.Collections.Generic;
using VMSM.Contracts.Entities;

namespace VMSM.Contracts.Interfaces
{
    public interface IVendingMachineProductService
    {
        VendingMachineProduct GetById(int id);
        IEnumerable<VendingMachineProduct> GetAll();
        VendingMachineProduct Create(VendingMachineProduct request);
        void Delete(int id);
    }
}
