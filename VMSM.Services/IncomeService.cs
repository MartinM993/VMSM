using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository<Income> _repository;

        public IncomeService(IRepository<Income> repository)
        {
            _repository = repository;
        }

        public Income GetById(int id)
        {
            var income = _repository.Get(id);

            return income;
        }

        public IEnumerable<Income> GetByCriteria(IncomeSearchRequest request)
        {
            var incomes = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.VendingMachineCode))
                incomes = incomes.Where(x => x.VendingMachine.Code.ToLower().Contains(request.VendingMachineCode.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.VendingMachineName))
                incomes = incomes.Where(x => x.VendingMachine.Name.ToLower().Contains(request.VendingMachineName.ToLower()));

            if (request.VendingMachineId.HasValue && request.VendingMachineId > 0)
                incomes = incomes.Where(x => x.VendingMachineId == request.VendingMachineId);

            return incomes;
        }

        public Income Create(Income request)
        {
            var income = _repository.Add(request);
            _repository.Save();

            return income;
        }
    }
}
