

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Election;

namespace Sadvo.Application.Interfaces
{
    public interface IElection : IBaseService<SaveElectionDTO, UpdateElectionDTO, DeleteElectionDTO>
    {
    }
}
