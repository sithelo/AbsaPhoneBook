using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int page, int size);
       // Task<IAsyncEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate, Func<T, string> orderBy);
    }
}
