using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IUserService
    {
        AppUser GetById(int id);
        IEnumerable<AppUser> GetByCriteria(UserSearchRequest request);
        AppUser Create(AppUser request);
        AppUser Update(AppUser request);
        void Delete(int id);
        void Delete(AppUser request);
    }
}
