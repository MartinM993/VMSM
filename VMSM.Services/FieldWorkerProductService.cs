using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class FieldWorkerProductService : IFieldWorkerProductService
    {
        private readonly IRepository<FieldWorkerProduct> _repository;

        public FieldWorkerProductService(IRepository<FieldWorkerProduct> repository)
        {
            _repository = repository;
        }

        public FieldWorkerProduct GetById(int id)
        {
            var fieldWorkerProduct = _repository.Get(id);

            return fieldWorkerProduct;
        }

        public IEnumerable<FieldWorkerProduct> GetByCriteria(FieldWorkerProductSearchRequest request)
        {
            var fieldWorkerProducts = _repository.GetAll();

            if (request.FieldWorkerId.HasValue)
                fieldWorkerProducts = fieldWorkerProducts.Where(x => x.FieldWorkerId == request.FieldWorkerId);
            if (request.ProductId.HasValue)
                fieldWorkerProducts = fieldWorkerProducts.Where(x => x.ProductId == request.ProductId);

            return fieldWorkerProducts;
        }

        public FieldWorkerProduct Create(FieldWorkerProduct request)
        {
            var fieldWorkerProduct = _repository.Add(request);
            _repository.Save();

            return fieldWorkerProduct;
        }

        public FieldWorkerProduct Update(FieldWorkerProduct request)
        {
            var fieldWorkerProduct = _repository.Update(request);
            _repository.Save();

            return fieldWorkerProduct;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
