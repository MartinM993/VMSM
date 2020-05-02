using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Services
{
    public class DefectService : IDefectService
    {
        private readonly IRepository<Defect> _repository;

        public DefectService(IRepository<Defect> repository)
        {
            _repository = repository;
        }

        public Defect GetById(int id)
        {
            var defect = _repository.Get(id);

            return defect;
        }

        public IEnumerable<Defect> GetAll()
        {
            var defects = _repository.GetAll();

            return defects;
        }

        public Defect Create(Defect request)
        {
            var defect = _repository.Add(request);
            _repository.Save();

            return defect;
        }
    }
}
