using Sadvo.Application.Base;
using Sadvo.Application.DTOs.PartyPolitical;

namespace Sadvo.Application.Interfaces
{
    public interface IPartyPoliticalService : IBaseService<SavePartyPoliticalDTO, UpdatePartyPoliticalDTO, DeletePartyPoliticalDTO>
    {
    }
}
