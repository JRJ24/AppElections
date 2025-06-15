

using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.IBaseRepository;

namespace Sadvo.Persistence.InterfacesRepositories.IElections
{
    public interface IElectionRepository : IBaseRepository<Election>
    {
    }
}
