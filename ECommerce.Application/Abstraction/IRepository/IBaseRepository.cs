using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T:BaseEntity, new()
    {
        #region Read
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression);
        Task<bool> IsExitAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression);
        #endregion



        #region Create
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        #endregion



        #region Update
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateRangeAsync(IEnumerable<T> entities);
        #endregion



        #region Delete
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> DeleteAsync(Guid Id);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> Ids);
        #endregion
    }
}
