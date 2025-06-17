

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Users;

namespace Sadvo.Application.Interfaces
{
    public interface IUserServices : IBaseService<SaveUsersDTO, UpdateUsersDTO, DeleteUsersDTO>
    {
    }
}
