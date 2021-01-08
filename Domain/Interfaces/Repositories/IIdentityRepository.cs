using Domain.Models.RequestResponse;
using System.Threading.Tasks;

namespace Domain.Models.Data.Interfaces.Repositories
{
    public interface IIdentityRepository
    {
        Task<bool> Register(RegisterRequestUser model);
        Task<LoginResponse> LogIn(LoginUserRequestModel model);
    }
}
