

using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.IBaseRepository;

namespace Sadvo.Persistence.InterfacesRepositories.IElections
{
    public interface IVotesRepository : IBaseRepository<Votes>
    {
    }
}
