using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.AliancePolitical;
using Sadvo.Application.DTOs.Candidatos;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;

namespace Sadvo.Application.Services
{
    public class CandidatosServices : ICandidatosServices
    {
        private readonly ICandidatosRepository _repository;
        private readonly ILogger<CandidatosServices> _logger;
        private readonly IMapper _mapper;

        public CandidatosServices(ICandidatosRepository repository, ILogger<CandidatosServices> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteCandidatosDTO dto)
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
                _logger.LogError($"CandidatosServices.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error removing aliance", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var candidatos = await _repository.GetAllAsync();
                var candidatosDTOs = _mapper.Map<IEnumerable<CandidatosDTO>>(candidatos);
                return OperationResult.GetSuccesResult(candidatosDTOs, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"CandidatosService.GetAll: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetById(int id)
        {
            if (id <= 0) return OperationResult.GetErrorResult("", code: 404);
            try
            {
                var candidatos = await _repository.GetEntityByIDAsync(id);
                if (candidatos == null) return OperationResult.GetErrorResult("", code: 404);

                var aliancePoliticalID = _mapper.Map<CandidatosDTO>(candidatos);
                return OperationResult.GetSuccesResult(aliancePoliticalID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CandidatosService.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveCandidatosDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Candidatos>(dto);
                entity.isActive = true;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CandidatosService.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateCandidatosDTO dto)
        {
            try
            {
                var candidatos = _mapper.Map<Candidatos>(dto);
                var candidatosUpdate = await _repository.UpdateEntityAsync(candidatos);
                if (!candidatosUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(candidatosUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"CandidatosService.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
