using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

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

        public IEnumerable<User> GetUsers(SearchUserRequest request)
        {
            var users = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Name))
                users = users.Where(x => x.Name.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.LastName))
                users = users.Where(x => x.LastName.Contains(request.LastName));

            if (!string.IsNullOrWhiteSpace(request.Email))
                users = users.Where(x => x.Email.Contains(request.Email));

            if (request.Role.HasValue)
                users = users.Where(x => x.Role == request.Role);

            return users;
        }

        public User CreateUser(User request)
        {
            var user = _repository.Add(request);
            _repository.Save();

            return user;
        }

        public User UpdateUser(User request)
        {
            var user = _repository.Update(request);
            _repository.Save();

            return user;
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
