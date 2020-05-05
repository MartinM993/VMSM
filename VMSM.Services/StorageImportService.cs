using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class StorageImportService : IStorageImportService
    {
        private readonly IRepository<StorageImport> _repository;

        public StorageImportService(IRepository<StorageImport> repository)
        {
            _repository = repository;
        }

        public StorageImport GetById(int id)
        {
            var storageImport = _repository.Get(id);

            return storageImport;
        }

        public IEnumerable<StorageImport> GetByCriteria(StorageImportSearchRequest request)
        {
            var storageImports = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.ProductName))
                storageImports = storageImports.Where(x => x.Product.Name.ToLower().Contains(request.ProductName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ProductCode))
                storageImports = storageImports.Where(x => x.Product.Code.ToLower().Contains(request.ProductCode.ToLower()));

            if (request.StorageWorkerId.HasValue)
                storageImports = storageImports.Where(x => x.CreatedBy == request.StorageWorkerId);

            if (request.ProductId.HasValue)
                storageImports = storageImports.Where(x => x.ProductId == request.ProductId);

            return storageImports;
        }

        public StorageImport Create(StorageImport request)
        {
            var storageImport = _repository.Add(request);
            _repository.Save();

            return storageImport;
        }
    }
}
