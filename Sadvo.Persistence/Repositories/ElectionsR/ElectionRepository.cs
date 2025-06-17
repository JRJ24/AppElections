

using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.InterfacesRepositories.IElections;

namespace Sadvo.Persistence.Repositories.ElectionsR
{
    public class ElectionRepository : BaseRepository<Election>, IElectionRepository
    {
        private readonly AppElectionsContext _context;
        private readonly ILogger<ElectionRepository> _logger;

        public ElectionRepository(AppElectionsContext context, ILogger<ElectionRepository> logger) : base(context) 
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<OperationResult> DeleteEntityAsync(Election entity)
        {
            if (entity is null) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var result = await base.GetEntityByIDAsync(entity.ElectionId);
                if (result is null) return OperationResult.GetErrorResult("", code: 404);

                result.isActiveElection = false;

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
        public override async Task<OperationResult> SaveEntityAsync(Election entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<Election> GetEntityByIDAsync(int id)
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
        public override async Task<OperationResult> UpdateEntityAsync(Election entity)
        {
            return await base.UpdateEntityAsync(entity);
        }
    }
}
