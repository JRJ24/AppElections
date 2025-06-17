using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.PartyPolitical;
using Sadvo.Application.DTOs.PoliticalLeader;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;

namespace Sadvo.Application.Services
{
    public class PoliticalLeaderService : IPoliticalLeaderServices
    {
        private readonly IPoliticalLeaderRepository _repository;
        private readonly ILogger<PoliticalLeaderService> _logger;
        private readonly IMapper _mapper;

        public PoliticalLeaderService(IPoliticalLeaderRepository repository, ILogger<PoliticalLeaderService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeletePoliticalLeaderDTO dto)
        {
            if (dto is null) return OperationResult.GetErrorResult("", code: 404);
            if (dto.Id <= 0) return OperationResult.GetErrorResult("", code: 404);

            try
            {
                var entityRemove = await _repository.GetEntityByIDAsync(dto.Id);
                if (entityRemove == null) return OperationResult.GetErrorResult("", code: 404);

                var result = await _repository.DeleteEntityAsync(entityRemove);
                return OperationResult.GetSuccesResult(result, "", code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"PartyPoliticalService.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<PoliticalLeaderDTO>>(entity);
                return OperationResult.GetSuccesResult(entitiesDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"PartyPoliticalService.GetAll: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetById(int id)
        {
            if (id <= 0) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var entity = await _repository.GetEntityByIDAsync(id);
                if (entity == null) return OperationResult.GetErrorResult("", code: 404);

                var entitiesID = _mapper.Map<PoliticalLeaderDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"PartyPoliticalService.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SavePoliticalLeaderDTO dto)
        {
            try
            {
                var entity = _mapper.Map<PoliticalLeader>(dto);
                entity.isActive = true;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"PartyPoliticalService.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdatePoliticalLeaderDTO dto)
        {
            try
            {
                var entity = _mapper.Map<PoliticalLeader>(dto);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"PartyPoliticalService.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
