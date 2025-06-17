
using Sadvo.Domain.BaseCommon;
using System.Linq.Expressions;

namespace Sadvo.Domain.IBaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityByIDAsync(int id);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<OperationResult> DeleteEntityAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter);

    }
}
