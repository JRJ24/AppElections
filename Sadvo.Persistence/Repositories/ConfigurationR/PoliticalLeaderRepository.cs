

using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;

namespace Sadvo.Persistence.Repositories.ConfigurationR
{
    public class PoliticalLeaderRepository : BaseRepository<PoliticalLeader>, IPoliticalLeaderRepository
    {
        private readonly AppElectionsContext _context;
        private readonly ILogger<PoliticalLeaderRepository> _logger;

        public PoliticalLeaderRepository(AppElectionsContext context, ILogger<PoliticalLeaderRepository> logger) : base(context) { 
            _context = context;
            _logger = logger;
        }

        public override async Task<OperationResult> DeleteEntityAsync(PoliticalLeader entity)
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
        public override async Task<OperationResult> SaveEntityAsync(PoliticalLeader entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<PoliticalLeader> GetEntityByIDAsync(int id)
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
        public override async Task<OperationResult> UpdateEntityAsync(PoliticalLeader entity)
        {
            return await base.UpdateEntityAsync(entity);
        }
    }
}
