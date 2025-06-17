

using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;
using Sadvo.Domain.Entities.Security;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;
using Sadvo.Persistence.Repositories.ElectionsR;

namespace Sadvo.Persistence.Repositories.SecurityR
{
    public class RolesRepository : BaseRepository<Roles>, IRolesRepository
    {
        private readonly AppElectionsContext _context;
        private readonly ILogger<RolesRepository> _logger;

        public RolesRepository(AppElectionsContext context, ILogger<RolesRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<OperationResult> DeleteEntityAsync(Roles entity)
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
        public override async Task<OperationResult> SaveEntityAsync(Roles entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<Roles> GetEntityByIDAsync(int id)
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
        public override async Task<OperationResult> UpdateEntityAsync(Roles entity)
        {
            return await base.UpdateEntityAsync(entity);
        }
    }
}
