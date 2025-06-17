using AutoMapper;
using Azure.Core;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.AliancePolitical;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;


namespace Sadvo.Application.Services
{
    public class AliancePoliticalService : IAliancePoliticalService
    {
        private readonly IAliancePoliticalRepository _repository;
        private readonly ILogger<AliancePoliticalService> _logger;
        private readonly IMapper _mapper;

        public AliancePoliticalService(IAliancePoliticalRepository repository, ILogger<AliancePoliticalService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteAliancePoliticalDTO dto)
        {
            if(dto is null) return OperationResult.GetErrorResult("", code: 404);
            if (dto.Id <= 0) return OperationResult.GetErrorResult("", code: 404);

            try
            {
                var entityRemove = await _repository.GetEntityByIDAsync(dto.Id);
                if (entityRemove == null) return OperationResult.GetErrorResult("", code: 404);

                var result = await _repository.DeleteEntityAsync(entityRemove);
                return OperationResult.GetSuccesResult(result, "", code:200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AliancePartyPolitical.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error removing aliance", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var aliancePolitical = await _repository.GetAllAsync();
                var aliancePoliticalDTO = _mapper.Map<IEnumerable<AliancePoliticalDTO>>(aliancePolitical);
                return OperationResult.GetSuccesResult(aliancePoliticalDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"AliancePartyPolitical.GetAll: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetById(int id)
        {
            if (id <= 0) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var aliancePolitical = await _repository.GetEntityByIDAsync(id);
                if(aliancePolitical == null) return OperationResult.GetErrorResult("", code: 404);

                var aliancePoliticalID = _mapper.Map<AliancePoliticalDTO>(aliancePolitical);
                return OperationResult.GetSuccesResult(aliancePoliticalID, code: 200);
            }
            catch(Exception ex)
            {
                _logger.LogError($"AliancePartyPolitical.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveAliancePoliticalDTO dto)
        {
            try
            {
                var aliancePolitical = _mapper.Map<AliancePolitical>(dto);
                aliancePolitical.isActive = true;
                var aliancePoliticalSave = await _repository.SaveEntityAsync(aliancePolitical);
                if (!aliancePoliticalSave.success) throw new Exception();

                return OperationResult.GetSuccesResult(aliancePoliticalSave, code: 200);

            }
            catch (Exception ex) 
            {
                _logger.LogError($"AliancePolitical.Save: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateAliancePoliticalDTO dto)
        {
            try
            {
                var aliancePolitical = _mapper.Map<AliancePolitical>(dto);
                var aliancePoliticalUpdate = await _repository.UpdateEntityAsync(aliancePolitical);
                if (!aliancePoliticalUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(aliancePoliticalUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"AliancePolitical.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
