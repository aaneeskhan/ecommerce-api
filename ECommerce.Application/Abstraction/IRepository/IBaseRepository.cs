using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression);


        //ADD

        Task AddAsync(T entity);
        Task AddRAngeAsync(IEnumerable<T> entities);

        //Update

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        //DELETE

        Task DeleteAsync(T entities);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IEnumerable<Guid> ids);
    }
}
