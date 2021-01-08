using Domain.Models.Data;
using Domain.Models.Data.Interfaces.Repositories;
using Domain.Models.RequestResponse;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<User> UserManager;

        public IdentityRepository(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        public async Task<LoginResponse> LogIn(LoginUserRequestModel model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == default)
            {
                throw new System.Exception("User was not found");
            }
            var passwordValid = await UserManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                throw new System.Exception("password doesnot match");
            }
            return new LoginResponse {
                Username = user.UserName,
                ID = user.Id
            };
        }

        public async Task<bool> Register(RegisterRequestUser model)
        {
            var user = new User
            {   
                UserName=model.Email,
                FullName = model.FullNAme,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                Zip = model.Zip
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return true;
            }
            else return false;
        }
    }
}
