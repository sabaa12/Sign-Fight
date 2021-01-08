using Domain.Models.RequestResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Causes;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sign2FightApi.Controllers.Cause2
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CauseController : ControllerBase
    {
        private ICausesService _causeService;
        private ISubscribesService _subscribeService;
        public CauseController(
            ICausesService service,
            ISubscribesService subscribeService
            )
        {
            _causeService = service;
            _subscribeService = subscribeService;
        }
        [HttpPost]
        [Route(nameof(CreateCause))]
        public async Task<ActionResult> CreateCause(CauseRequestModel model)
        {
            if (await _causeService.AddCause(User.FindFirst(ClaimTypes.NameIdentifier).Value, model))
            {
                return Ok("cause was created");
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route(nameof(GetCauses))]
        public async Task<IQueryable<CauseRequestModel>> GetCauses()
            =>
            await _causeService.GetCauses(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        [HttpGet]
        [Route(nameof(GetAllCauses))]
        public async Task<IQueryable<CauseRequestModel>> GetAllCauses()
            =>
            await _causeService.GetAllCauses();

        [HttpPost]
        [Route(nameof(AddSubscribe))]
        public async Task<ActionResult> AddSubscribe(int causeID)
        {

            if (await _subscribeService.AddSubscribes(causeID, User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Ok("created");
            }
            return Unauthorized();
        }
    }
}
