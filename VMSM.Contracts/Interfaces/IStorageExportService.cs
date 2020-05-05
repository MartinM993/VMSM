using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IStorageExportService
    {
        StorageExport GetById(int id);
        IEnumerable<StorageExport> GetByCriteria(StorageExportSearchRequest request);
        StorageExport Create(StorageExport request);
    }
}
