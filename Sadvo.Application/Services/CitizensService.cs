

using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.Candidatos;
using Sadvo.Application.DTOs.Citizens;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.Citizens;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.InterfacesRepositories.IElections;

namespace Sadvo.Application.Services
{
    public class CitizensService : ICitizensServices
    {
        private readonly ICitizenRepository _repository;
        private readonly ILogger<CitizensService> _logger;
        private readonly IMapper _mapper;

        public CitizensService(ICitizenRepository repository, ILogger<CitizensService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteCitizensDTO dto)
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
                _logger.LogError($"CitizensService.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var citizens = await _repository.GetAllAsync();
                var citizensDTOs = _mapper.Map<IEnumerable<CitizensDTO>>(citizens);
                var citizensViewModels = _mapper.Map<IEnumerable<CitizensViewModel>>(citizensDTOs);
                return OperationResult.GetSuccesResult(citizensViewModels, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"CitizensService.GetAll: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetById(int id)
        {
            if (id <= 0) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var citizens = await _repository.GetEntityByIDAsync(id);
                if (citizens == null) return OperationResult.GetErrorResult("", code: 404);

                var citizensID = _mapper.Map<CitizensDTO>(citizens);
                return OperationResult.GetSuccesResult(citizensID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CitizensService.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveCitizensDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Citizens>(dto);
                entity.isActive = true;
                entity.isVoted = false;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CitizensService.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateCitizensDTO dto)
        {
            try
            {
                var citizens = _mapper.Map<Citizens>(dto);
                var citizensUpdate = await _repository.UpdateEntityAsync(citizens);
                if (!citizensUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(citizensUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"CitizensService.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
