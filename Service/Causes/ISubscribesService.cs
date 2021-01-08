using System.Threading.Tasks;

namespace Service.Causes
{
    public interface ISubscribesService
    {
        public Task<bool> AddSubscribes(int CauseID, string UserID);

    }
}
