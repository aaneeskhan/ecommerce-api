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

        Task<int> AddAsync(T entity);
        Task<int> AddRAngeAsync(IEnumerable<T> entities);

        //Update

        Task<int> UpdateAsync(T entity);
        Task<int> UpdateRangeAsync(IEnumerable<T> entities);

        //DELETE

        Task<int> DeleteAsync(T entities);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> ids);
    }
}
