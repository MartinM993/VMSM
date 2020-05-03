using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IIncomeService
    {
        Income GetById(int id);
        IEnumerable<Income> GetByCriteria(IncomeSearchRequest request);
        Income Create(Income request);
    }
}
