using Domain.Models.Data;
using Domain.Models.RequestResponse;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Causes
{
    public interface ICausesService
    {
        public Task<bool> AddCause(string UserID,CauseRequestModel model);
        public Task<IQueryable<CauseRequestModel>>GetCauses(string UserID);
        public Task<IQueryable<CauseRequestModel>> GetAllCauses();

    }
}
