
using Microsoft.Extensions.Logging;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.IBaseRepository;
using Sadvo.Persistence.Base;
using Sadvo.Persistence.Context;
using Sadvo.Persistence.EntityConfigurationsORM;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using System.Linq.Expressions;

namespace Sadvo.Persistence.Repositories.ConfigurationR
{
    public class AliancePoliticalRepository : BaseRepository<AliancePolitical>, IAliancePoliticalRepository
    {
        private readonly AppElectionsContext _appElectionsContext;
        private readonly ILogger<AliancePoliticalRepository> _logger;

        public AliancePoliticalRepository(AppElectionsContext appElectionsContext, ILogger<AliancePoliticalRepository> logger) : base(appElectionsContext) 
        {
            _appElectionsContext = appElectionsContext;
            _logger = logger;
        }

        public override async Task<OperationResult> DeleteEntityAsync(AliancePolitical entity)
        {
            if (entity is null) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var result = await base.GetEntityByIDAsync(entity.Id);
                if (result is null) return OperationResult.GetErrorResult("", code: 404);

                result.isActive = false;

                var resultDelete = await UpdateEntityAsync(result);
                if(!resultDelete.success) return OperationResult.GetErrorResult("", code: 500);

                return OperationResult.GetSuccesResult(resultDelete, "", code: 200);
            }
            catch(Exception ex)
            {
                _logger.LogError("");
                return OperationResult.GetErrorResult("", code: 500);
            }
        }
        public override async Task<OperationResult> SaveEntityAsync(AliancePolitical entity)
        {
            return await base.SaveEntityAsync(entity);
        }
        public override async Task<AliancePolitical> GetEntityByIDAsync(int id)
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
        public override async Task<OperationResult> UpdateEntityAsync(AliancePolitical entity)
        {
            return await base.UpdateEntityAsync(entity);
        }

    }
}
