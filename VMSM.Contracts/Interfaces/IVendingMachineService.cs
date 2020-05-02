using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IVendingMachineService
    {
        VendingMachine GetById(int id);
        IEnumerable<VendingMachine> GetByCriteria(VendingMachineSearchRequest request);
        VendingMachine Create(VendingMachine request);
        VendingMachine Update(VendingMachine request);
        void Delete(int id);
    }
}
