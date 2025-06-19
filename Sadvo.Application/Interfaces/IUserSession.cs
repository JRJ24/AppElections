
using Sadvo.Application.ViewModels.Users;

namespace Sadvo.Application.Interfaces
{
    internal interface IUserSession
    {
        UsersViewModel? GetUserSession();
        bool HasUser();
        bool IsAdmin();
    }
}
