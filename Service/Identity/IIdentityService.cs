using Domain.Models.RequestResponse;
using System.Threading.Tasks;

namespace Service.Identity
{
    public interface IIdentityService 
    {
        public  Task<TokenResponse> LogIn(LoginUserRequestModel model);
        public Task<bool> Register(RegisterRequestUser model);
        public string GenerateToken(string userid, string userName, string secret);
    }
}
