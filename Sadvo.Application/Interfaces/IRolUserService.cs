

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.RolUsers;

namespace Sadvo.Application.Interfaces
{
    public interface IRolUserService : IBaseService<SaveRolUsersDTO, UpdateRolUsersDTO, DeleteRolUsersDTO>
    {
    }
}
