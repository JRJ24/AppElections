

using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.IBaseRepository;

namespace Sadvo.Persistence.InterfacesRepositories.IElections
{
    public interface IElectionRepository : IBaseRepository<Election>
    {
        Task<OperationResult> GetEntityByYearAsync(int year);
    }
}
