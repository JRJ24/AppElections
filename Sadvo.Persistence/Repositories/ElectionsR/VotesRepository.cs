

using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.InterfacesRepositories.IElections;

namespace Sadvo.Persistence.Repositories.ElectionsR
{
    public class VotesRepository : BaseRepository<Votes>, IVotesRepository
    {
        private readonly AppElectionsContext _context;
        private readonly ILogger<VotesRepository> _logger;

        public VotesRepository(AppElectionsContext context, ILogger<VotesRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

       /* public override async Task<OperationResult> DeleteEntityAsync(Votes entity)
        {
            if (entity is null) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var result = await base.GetEntityByIDAsync(entity.ID);
                if (result is null) return OperationResult.GetErrorResult("", code: 404);

                result. = false;

                var resultDelete = await UpdateEntityAsync(result);
                if (!resultDelete.success) return OperationResult.GetErrorResult("", code: 500);

                return OperationResult.GetSuccesResult(resultDelete, "", code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("");
                return OperationResult.GetErrorResult("", code: 500);
            }
        } */
        public override async Task<OperationResult> SaveEntityAsync(Votes entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<Votes> GetEntityByIDAsync(int id)
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
        public override async Task<OperationResult> UpdateEntityAsync(Votes entity)
        {
            return await base.UpdateEntityAsync(entity);
        }
    }
}
