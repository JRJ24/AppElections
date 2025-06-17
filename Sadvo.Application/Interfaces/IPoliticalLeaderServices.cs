
using Sadvo.Application.Base;
using Sadvo.Application.DTOs.PoliticalLeader;

namespace Sadvo.Application.Interfaces
{
    public interface IPoliticalLeaderServices : IBaseService<SavePoliticalLeaderDTO, UpdatePoliticalLeaderDTO, DeletePoliticalLeaderDTO>
    {
    }
}
