using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IProductService
    {
        Product GetById(int id);
        IEnumerable<Product> GetByCriteria(ProductSearchRequest request);
        Product Create(Product request);
        Product Update(Product request);
        void Delete(int id);
    }
}
