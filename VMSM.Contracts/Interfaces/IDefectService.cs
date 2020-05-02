using System.Collections.Generic;
using VMSM.Contracts.Entities;

namespace VMSM.Contracts.Interfaces
{
    public interface IDefectService
    {
        Defect GetById(int id);
        IEnumerable<Defect> GetAll();
        Defect Create(Defect request);
    }
}
