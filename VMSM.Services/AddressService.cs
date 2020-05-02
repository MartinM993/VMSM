using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _repository;

        public AddressService(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public Address GetById(int id)
        {
            var address = _repository.Get(id);

            return address;
        }

        public IEnumerable<Address> GetByCriteria(AddressSearchRequest request)
        {
            var addresses = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Line1))
                addresses = addresses.Where(x => x.Line1.ToLower().Contains(request.Line1.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ZipCode))
                addresses = addresses.Where(x => x.ZipCode.ToLower().Contains(request.ZipCode.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Town))
                addresses = addresses.Where(x => x.Town.ToLower().Contains(request.Town.ToLower()));

            return addresses;
        }

        public Address Create(Address request)
        {
            var address = _repository.Add(request);
            _repository.Save();

            return address;
        }

        public Address Update(Address request)
        {
            var address = _repository.Update(request);
            _repository.Save();

            return address;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
