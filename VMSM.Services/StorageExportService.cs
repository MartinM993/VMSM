using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class StorageExportService : IStorageExportService
    {
        private readonly IRepository<StorageExport> _repository;

        public StorageExportService(IRepository<StorageExport> repository)
        {
            _repository = repository;
        }

        public StorageExport GetById(int id)
        {
            var storageExport = _repository.Get(id);

            return storageExport;
        }

        public IEnumerable<StorageExport> GetByCriteria(StorageExportSearchRequest request)
        {
            var storageExports = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerName))
                storageExports = storageExports.Where(x => x.FieldWorker.Name.ToLower().Contains(request.FieldWorkerLastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.FieldWorkerLastName))
                storageExports = storageExports.Where(x => x.FieldWorker.LastName.ToLower().Contains(request.FieldWorkerLastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ProductName))
                storageExports = storageExports.Where(x => x.Product.Name.ToLower().Contains(request.ProductName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.ProductCode))
                storageExports = storageExports.Where(x => x.Product.Code.ToLower().Contains(request.ProductCode.ToLower()));

            if (request.FieldWorkerId.HasValue)
                storageExports = storageExports.Where(x => x.FieldWorkerId == request.FieldWorkerId);

            if (request.StorageWorkerId.HasValue)
                storageExports = storageExports.Where(x => x.CreatedBy == request.StorageWorkerId);

            if (request.ProductId.HasValue)
                storageExports = storageExports.Where(x => x.ProductId == request.ProductId);

            return storageExports;
        }

        public StorageExport Create(StorageExport request)
        {
            var storageExport = _repository.Add(request);
            _repository.Save();

            return storageExport;
        }
    }
}
