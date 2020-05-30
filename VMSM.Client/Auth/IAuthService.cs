using System.Threading.Tasks;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Models;

namespace VMSM.Client.Auth
{
    public interface IAuthService
    {
        Task<CustomActionResult> Login(Login loginModel);
        Task Logout();
    }
}
