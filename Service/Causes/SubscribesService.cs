using Domain.Interfaces.Repositories;
using Domain.Models.Data;
using System.Threading.Tasks;

namespace Service.Causes
{
    public class SubscribesService : ISubscribesService
    {
        private ISubScribesRepository _repository;

        public SubscribesService(ISubScribesRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddSubscribes(int CauseID, string UserID)
        {
            _repository.Create(new SubScribes
            {
                CauseID = CauseID,
                UserID = UserID
            });
            return  _repository.Save(); 
        }
    }
}
