

using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.PartyPolitical;
using Sadvo.Application.DTOs.PoliticalLeader;
using Sadvo.Application.DTOs.Roles;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Security;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;

namespace Sadvo.Application.Services
{
    public class RolServices : IRolService
    {
        private readonly IRolesRepository _repository;
        private readonly ILogger<RolServices> _logger;
        private readonly IMapper _mapper;

        public RolServices(IRolesRepository repository, ILogger<RolServices> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteRolesDTO dto)
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
                _logger.LogError($"RolServices.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<RolesDTO>>(entity);
                return OperationResult.GetSuccesResult(entitiesDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"RolServices.GetAll: {ex}");
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

                var entitiesID = _mapper.Map<RolesDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RolServices.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveRolesDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Roles>(dto);
                entity.isActive = true;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RolServices.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateRolesDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Roles>(dto);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"RolServices.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
