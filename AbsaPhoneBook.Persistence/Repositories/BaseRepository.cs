using AbsaPhoneBook.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AbsaDbContext _dbContext;

        public BaseRepository(AbsaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int page, int size)
        {
           
            return await _dbContext.Set<T>().Where(predicate).Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        //public async virtual Task<IReadOnlyList<T>> GetByNameAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy)
        //{
        //    return await _dbContext.Set<T>().Where(predicate).OrderBy(orderBy).AsQueryable().AsNoTracking().ToListAsync();            
        //}

        //public async virtual Task<IAsyncEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate, Func<T, string> orderBy)
        //{
        //    return await _dbContext.Set<T>().Where(predicate).OrderBy(orderBy).AsQueryable().AsNoTracking().ToArrayAsync();
        //}

    }
}
