using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetByCriteria(SearchUserRequest request);
        User Create(User request);
        User Update(User request);
        void Delete(int id);
    }
}
