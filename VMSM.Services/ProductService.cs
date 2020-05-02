using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product GetById(int id)
        {
            var product = _repository.Get(id);

            return product;
        }

        public IEnumerable<Product> GetByCriteria(ProductSearchRequest request)
        {
            var products = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Name))
                products = products.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Code))
                products = products.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));

            if (request.Category.HasValue)
                products = products.Where(x => x.Category == request.Category);

            return products;
        }

        public Product Create(Product request)
        {
            var product = _repository.Add(request);
            _repository.Save();

            return product;
        }

        public Product Update(Product request)
        {
            var product = _repository.Update(request);
            _repository.Save();

            return product;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
