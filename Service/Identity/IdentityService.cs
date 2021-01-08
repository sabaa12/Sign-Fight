using Domain.Models.Data.Interfaces.Repositories;
using Domain.Models.RequestResponse;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Identity
{
   public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _repository;
        private readonly ApplicationSetings appSetings;
        public IdentityService(IIdentityRepository repository, IOptions<ApplicationSetings> appSetings)
        { 
            this.appSetings = appSetings.Value;
            _repository = repository;
            
        }

        public string GenerateToken(string userid, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, userid),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<TokenResponse> LogIn(LoginUserRequestModel model)
        {
            LoginResponse result = new();
            try
            { 
                 result=await _repository.LogIn(model);
            }
            catch (Exception)
            {

                throw;
            }
           
            var token = GenerateToken(result.ID, result.Username, "this is secret this is secret this is secret this is secret this is secret this is secret this is secret");
            return  new TokenResponse { Token=token};
        }
            



        public Task<bool> Register(RegisterRequestUser model)
        =>
            _repository.Register(model);
    }
}
