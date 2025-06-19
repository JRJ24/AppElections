using AutoMapper;
using Microsoft.Extensions.Logging;
using Sadvo.Application.DTOs.Roles;
using Sadvo.Application.DTOs.Users;
using Sadvo.Application.Interfaces;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.Entities.Security;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;
using Sadvo.Utils.Helpers;


namespace Sadvo.Application.Services
{
    public class UsersService : IUserServices
    {
        private readonly IUsersRepository _repository;
        private readonly ILogger<UsersService> _logger;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository repository, ILogger<UsersService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> DeleteById(DeleteUsersDTO dto)
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
                _logger.LogError($"UsersService.DeleteById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                var entitiesDTO = _mapper.Map<IEnumerable<UsersDTO>>(entity);
                return OperationResult.GetSuccesResult(entitiesDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"UsersService.GetAll: {ex}");
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

                var entitiesID = _mapper.Map<UsersDTO>(entity);
                return OperationResult.GetSuccesResult(entitiesID, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UsersService.GetById: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> Save(SaveUsersDTO dto)
        {
            try
            {
                var existingUser = await _repository.VerifyUserName(dto.userName);
                if (existingUser.success) return OperationResult.GetErrorResult("Usuario ya existe", code: 400);

                var entity = _mapper.Map<Users>(dto);
                entity.isActive = true;
                entity.password = PasswordEncrypted.ComputeSha256Hash(dto.password);
                var entitySave = await _repository.SaveEntityAsync(entity);
                if (!entitySave.success) throw new Exception();

                return OperationResult.GetSuccesResult(entitySave, code: 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UsersService.Save: {ex}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UpdateById(UpdateUsersDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Users>(dto);
                entity.password = PasswordEncrypted.ComputeSha256Hash(dto.password);
                var entityUpdate = await _repository.UpdateEntityAsync(entity);
                if (!entityUpdate.success) throw new Exception();

                return OperationResult.GetSuccesResult(entityUpdate, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"UsersService.UpdateById: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }
        }

        public async Task<OperationResult> UserLogin(LoginDTO dto)
        {
            try
            {
                Users users = await _repository.LoginAsync(dto.userName, dto.password);
                if(users == null) return OperationResult.GetErrorResult("", code:404);

                var userDTO = _mapper.Map<UsersDTO>(users);
                return OperationResult.GetSuccesResult(userDTO, code: 200);

            }
            catch (Exception ex)
            {
                _logger.LogError($"UsersService.UserLogin: {ex.ToString()}");
                return OperationResult.GetErrorResult("Error", code: 500);
            }


        }
    }
}
