

using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Security;
using Sadvo.Domain.IBaseRepository;

namespace Sadvo.Persistence.InterfacesRepositories.ISecurity
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        Task<Users> LoginAsync(string username, string password);
        Task<OperationResult> VerifyUserName(string username);
    }
}
