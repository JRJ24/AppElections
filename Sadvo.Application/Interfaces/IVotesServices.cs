

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Votes;
using Sadvo.Domain.IBaseRepository;

namespace Sadvo.Application.Interfaces
{
    public interface IVotesServices : IBaseService<SaveVotesDTO, UpdateVotesDTO, InvalidVotesDTO>
    {
    }
}
