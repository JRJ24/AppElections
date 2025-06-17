

using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.ElectivePositions;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;

namespace Sadvo.Application.Services
{
    public class ElectivePositionsService : IElectivePositionsServices
    {
        private readonly IElectivePositionsRepository _repository;
        private readonly ILogger<ElectivePositionsService> _logger;
        private readonly IMapper _mapper;

        public ElectivePositionsService(IElectivePositionsRepository repository, ILogger<ElectivePositionsService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteElectivePositionsDTO dto)
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
                _logger.LogError($"ElectivePositions.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<ElectivePositionsDTO>>(entity);
                return OperationResult.GetSuccesResult(entitiesDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectivePositions.GetAll: {ex}");
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

                var entitiesID = _mapper.Map<ElectivePositionsDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectivePositions.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveElectivePositionsDTO dto)
        {
            try
            {
                var entity = _mapper.Map<ElectivePositions>(dto);
                entity.isActive = true;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectivePositions.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateElectivePositionsDTO dto)
        {
            try
            {
                var entity = _mapper.Map<ElectivePositions>(dto);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectivePositions.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
