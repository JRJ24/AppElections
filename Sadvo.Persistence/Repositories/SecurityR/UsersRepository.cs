

using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Security;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;

namespace Sadvo.Persistence.Repositories.SecurityR
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private readonly AppElectionsContext _context;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(AppElectionsContext context, ILogger<UsersRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<OperationResult> DeleteEntityAsync(Users entity)
        {
            if (entity is null) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var result = await base.GetEntityByIDAsync(entity.Id);
                if (result is null) return OperationResult.GetErrorResult("", code: 404);

                result.isActive = false;

                var resultDelete = await UpdateEntityAsync(result);
                if (!resultDelete.success) return OperationResult.GetErrorResult("", code: 500);

                return OperationResult.GetSuccesResult(resultDelete, "", code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("");
                return OperationResult.GetErrorResult("", code: 500);
            }
        }
        public override async Task<OperationResult> SaveEntityAsync(Users entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<Users> GetEntityByIDAsync(int id)
        {
            try
            {
                var result = await base.GetEntityByIDAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("");
                return null;
            }
        }
        public override async Task<OperationResult> UpdateEntityAsync(Users entity)
        {
            return await base.UpdateEntityAsync(entity);
        }
    }
}
