

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Citizens;

namespace Sadvo.Application.Interfaces
{
    public interface ICitizensServices : IBaseService<SaveCitizensDTO, UpdateCitizensDTO, DeleteCitizensDTO>
    {
    }
}
