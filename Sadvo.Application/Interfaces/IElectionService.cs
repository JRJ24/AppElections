

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Election;
using Sadvo.Domain.BaseCommon;

namespace Sadvo.Application.Interfaces
{
    public interface IElectionService : IBaseService<SaveElectionDTO, UpdateElectionDTO, DeleteElectionDTO>
    {
        Task<OperationResult> GetEntitiesByYearAsync(int year);
    }
}
