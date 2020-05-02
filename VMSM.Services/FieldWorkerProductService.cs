using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

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
