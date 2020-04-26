using VMSM.Contracts.Entities;

namespace VMSM.Contracts.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
    }
}
