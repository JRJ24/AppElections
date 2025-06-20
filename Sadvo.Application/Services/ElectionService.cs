

using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.Election;
using Sadvo.Application.DTOs.PartyPolitical;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.Election;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Persistence.InterfacesRepositories.IElections;

namespace Sadvo.Application.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionRepository _repository;
        private readonly ILogger<ElectionService> _logger;
        private readonly IMapper _mapper;

        public ElectionService(IElectionRepository repository, ILogger<ElectionService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteElectionDTO dto)
        {
            if (dto is null) return OperationResult.GetErrorResult("", code: 404);
            if (dto.ElectionId <= 0) return OperationResult.GetErrorResult("", code: 404);

            try
            {
                var entityRemove = await _repository.GetEntityByIDAsync(dto.ElectionId);
                if (entityRemove == null) return OperationResult.GetErrorResult("", code: 404);

                var result = await _repository.DeleteEntityAsync(entityRemove);
                return OperationResult.GetSuccesResult(result, "", code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<ElectionDTO>>(entity);
                var entitiesViewModel = _mapper.Map<IEnumerable<ElectionViewModel>>(entitiesDTO);
                return OperationResult.GetSuccesResult(entitiesViewModel, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.GetAll: {ex}");
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

                var entitiesID = _mapper.Map<ElectionDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetEntitiesByYearAsync(int year)
        {
            if (year <= 0) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var entity = await _repository.GetEntityByYearAsync(year);
                if (entity == null) return OperationResult.GetErrorResult("", code: 404);

                var entitiesYears = _mapper.Map<ElectionDTO>(entity);
                var entitiesViewModel = _mapper.Map<ElectionViewModel>(entitiesYears);
                return OperationResult.GetSuccesResult(entitiesViewModel, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.GetEntitiesByYearAsync: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveElectionDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Election>(dto);
                entity.isActiveElection = false;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateElectionDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Election>(dto);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ElectionService.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
