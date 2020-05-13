using System.Threading.Tasks;
using VMSM.Contracts.Models;

namespace VMSM.Client.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Login(Login loginModel);
        Task Logout();
    }
}
