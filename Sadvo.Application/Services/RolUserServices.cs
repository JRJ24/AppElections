

using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.Roles;
using Sadvo.Application.DTOs.RolUsers;
using Sadvo.Application.Interfaces;
using Sadvo.Application.ViewModels.RolUser;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Security;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;

namespace Sadvo.Application.Services
{
    public class RolUserServices : IRolUserService
    {
        private readonly IRolUsersRepository _repository;
        private readonly ILogger<RolUserServices> _logger;
        private readonly IMapper _mapper;

        public RolUserServices(IRolUsersRepository repository, ILogger<RolUserServices> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteRolUsersDTO dto)
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
                _logger.LogError($"RolUserServices.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<RolUsersDTO>>(entity);
                var entitesViewModel = _mapper.Map<IEnumerable<RolUserViewModel>>(entitiesDTO);
                return OperationResult.GetSuccesResult(entitesViewModel, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"RolUserServices.GetAll: {ex}");
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

                var entitiesID = _mapper.Map<RolUsersDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RolUserServices.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveRolUsersDTO dto)
        {
            try
            {
                var entity = _mapper.Map<RolUsers>(dto);
                entity.isActive = true;
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RolUserServices.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateRolUsersDTO dto)
        {
            try
            {
                var entity = _mapper.Map<RolUsers>(dto);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"RolUserServices.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }
    }
}
