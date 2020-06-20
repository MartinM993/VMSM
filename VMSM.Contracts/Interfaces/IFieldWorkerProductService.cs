using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IFieldWorkerProductService
    {
        FieldWorkerProduct GetById(int id);
        IEnumerable<FieldWorkerProduct> GetByCriteria(FieldWorkerProductSearchRequest request);
        FieldWorkerProduct Create(FieldWorkerProduct request);
        FieldWorkerProduct Update(FieldWorkerProduct request);
        void Delete(int id);
    }
}
