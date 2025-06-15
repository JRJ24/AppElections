

using Microsoft.EntityFrameworkCore;
using Sadvo.Domain.BaseCommon;
using Sadvo.Domain.IBaseRepository;
using Sadvo.Persistence.Context;
using System.Linq.Expressions;

namespace Sadvo.Persistence.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppElectionsContext _context;
        private DbSet<TEntity>? Entity {  get; set; }
        public BaseRepository(AppElectionsContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }

        public virtual async Task<OperationResult> DeleteEntityById(TEntity entity)
        {
            if (entity == null) return OperationResult.GetErrorResult("", code: 400);
            try
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                var saveResult = await _context.SaveChangesAsync();

                return OperationResult.GetSuccesResult(saveResult, "", code: 200);
            }
            catch (Exception ex)
            {
                return OperationResult.GetErrorResult("", code: 500);
            }
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entity.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var datos = await Entity.Where(filter).ToListAsync();

                return OperationResult.GetSuccesResult(datos, "", code: 200);
            }
            catch (Exception ex) {
                return OperationResult.GetErrorResult("", code: 500);
            }
        }

        public async Task<TEntity> GetEntityByIDAsync(int id)
        {
            if (Entity == null)
            {
                throw new InvalidOperationException("");
            }

            var entity = await Entity.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} was not found.");
            }

            return entity;
        }

        public async Task<OperationResult> SaveEntityById(TEntity entity)
        {
            try
            {
                Entity.Add(entity);
                var result = await _context.SaveChangesAsync();
                return OperationResult.GetSuccesResult(result, "", code: 200);
            }catch (Exception ex)
            {
                return OperationResult.GetErrorResult("", code: 500);
            }
        }

        public async Task<OperationResult> UpdateEntityById(TEntity entity)
        {
            if (entity == null) return OperationResult.GetErrorResult("", code: 400);
            try
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                var saveResult = await _context.SaveChangesAsync();

                return OperationResult.GetSuccesResult(saveResult, "", code: 200);
            }
            catch (Exception ex)
            {
                return OperationResult.GetErrorResult("", code: 500);
            }
        }
    }
}
