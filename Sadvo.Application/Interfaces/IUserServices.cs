

using Sadvo.Application.Base;
using Sadvo.Application.DTOs.Users;
using Sadvo.Application.ViewModels.Users;
using Sadvo.Domain.BaseCommon;

namespace Sadvo.Application.Interfaces
{
    public interface IUserServices : IBaseService<SaveUsersDTO, UpdateUsersDTO, DeleteUsersDTO>
    {
        Task<OperationResult> UserLogin(LoginUserViewModel ViewModel);
    }
}
