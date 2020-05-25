using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;
using VMSM.Contracts.Requests;

namespace VMSM.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _repository;

        public UserService(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public AppUser GetById(int id)
        {
            var user = _repository.Get(id);

            return user;
        }

        public IEnumerable<AppUser> GetByCriteria(UserSearchRequest request)
        {
            var users = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.Name))
                users = users.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.LastName))
                users = users.Where(x => x.LastName.ToLower().Contains(request.LastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Email))
                users = users.Where(x => x.Email.ToLower().Contains(request.Email.ToLower()));

            if (request.Role.HasValue)
                users = users.Where(x => x.UserRole == request.Role);

            return users;
        }

        public AppUser Create(AppUser request)
        {
            var user = _repository.Add(request);
            _repository.Save();

            return user;
        }

        public AppUser Update(AppUser request)
        {
            var user = _repository.Update(request);
            _repository.Save();

            return user;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public void Delete(AppUser request)
        {
            _repository.Delete(request);
            _repository.Save();
        }
    }
}
