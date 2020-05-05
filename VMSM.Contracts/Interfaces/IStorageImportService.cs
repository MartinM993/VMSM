using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IStorageImportService
    {
        StorageImport GetById(int id);
        IEnumerable<StorageImport> GetByCriteria(StorageImportSearchRequest request);
        StorageImport Create(StorageImport request);
    }
}
