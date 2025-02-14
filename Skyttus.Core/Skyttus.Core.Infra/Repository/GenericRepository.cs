using Microsoft.EntityFrameworkCore;
using Skyttus.Core.Entity.Contracts;
using Skyttus.Core.Infra.Contracts;
using System.Linq.Expressions;

namespace Skyttus.Core.Infra.Repository
{
    public abstract class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class, IBaseEntity
    {
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context) : base(context)
           => (_dbSet) = (context.Set<T>());

        public async virtual Task<IQueryable<T>> GetAll(bool trackChanges = false)
        {
            using (var scope = CreateTransactionAsync(trackChanges))
            {
                var result =
                     trackChanges ?
                     await Task.FromResult(_dbSet) :
                     await Task.FromResult(_dbSet.AsNoTracking());
                scope.Complete();
                return result;
            }
        }

        public async virtual Task<IQueryable<T>> GetAll(int pageNumber, int pageSize, bool trackChanges = false)
        {
            using (var scope = CreateTransactionAsync(trackChanges))
            {
                var pageNo = pageNumber - 1;
                var result =
                     trackChanges ?
                     await Task.FromResult(_dbSet.Skip(pageNo * pageSize).Take(pageSize)) :
                     await Task.FromResult(_dbSet.Skip(pageNo * pageSize).Take(pageSize).AsNoTracking());
                scope.Complete();
                return result;
            }
        }

        public async virtual Task<T?> GetById(Guid id, bool trackChanges = false)
        {
            using (var scope = CreateTransactionAsync(trackChanges))
            {
                var result =
                    trackChanges ?
                        await _dbSet.FirstOrDefaultAsync(x => x.Id == id) :
                        await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                scope.Complete();
                return result;
            }
        }

        public async virtual Task<T> Add(T entity)
        {
            var result = await Task.FromResult(_dbSet.Add(entity));
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task<T> Update(T entity)
        {
            var result = await Task.FromResult(_dbSet.Update(entity));
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
              

        public async virtual Task<List<T>> AddMultiple(List<T> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
    }
}
