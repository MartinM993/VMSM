using Microsoft.EntityFrameworkCore.Storage;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Data;

namespace VMSM.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User GetUserById(int id)
        {
            var user = _repository.Get(id);
            return user;
        }
        
    }
}
