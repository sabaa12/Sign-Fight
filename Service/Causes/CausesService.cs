using Domain.Interfaces.Repositories;
using Domain.Models.Data;
using Domain.Models.RequestResponse;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Causes
{
    public class CausesService : ICausesService
    {
        private ICauseRepository _repository;

        public CausesService(ICauseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddCause(string UserID,CauseRequestModel model)
        {
            Cause cause = new Cause
            {
                Title = model.Title,
                Description = model.Description,
                UserID =UserID,
                
            };
            _repository.Create(cause);
            return _repository.Save();
        }

        public async Task<IQueryable<CauseRequestModel>> GetAllCauses()
            =>
             _repository
            .FindAll()
            .Select
            (x => new CauseRequestModel
            {
                CauseID = x.ID,
                Title = x.Title,
                Description = x.Description,
                UserID = x.UserID,
            }
            );

        public async Task<IQueryable<CauseRequestModel>> GetCauses(string UserID)
            =>
             _repository
            .Find(x => x.UserID == UserID)
            .Select
            (x => new CauseRequestModel
                {   
                    CauseID=x.ID,
                    Title = x.Title,
                    Description = x.Description,
                    UserID = x.UserID,
                }
            );

    }
}
