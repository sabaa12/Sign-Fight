using Domain.Models.RequestResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sign2FightApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IIdentityService _service;

        public IdentityController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestUser model)
        {
            if (await _service.Register(model))
            {
                return Ok("registered");
            }
            return BadRequest();
        }
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<TokenResponse>> Login(LoginUserRequestModel model)
        {
            TokenResponse token;
            try
            {
                token=await _service.LogIn(model);
            }
            catch (Exception ex)
            {

                return Unauthorized(ex.Message);
            }
         

            return token;
        }
    }
}
