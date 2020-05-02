using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IAddressService
    {
        Address GetById(int id);
        IEnumerable<Address> GetByCriteria(AddressSearchRequest request);
        Address Create(Address request);
        Address Update(Address request);
        void Delete(int id);
    }
}
