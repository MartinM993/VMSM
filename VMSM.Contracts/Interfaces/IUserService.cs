using System.Collections.Generic;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Requests;

namespace VMSM.Contracts.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        IEnumerable<User> GetUsers(SearchUserRequest request);
        User CreateUser(User request);
        User UpdateUser(User request);
        void DeleteUser(int id);
    }
}
