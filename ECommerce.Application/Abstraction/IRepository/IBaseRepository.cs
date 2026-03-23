using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T:BaseEntity,new()
    {
        //Read
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression);

        Task<bool> ISExistAsync(Expression<Func<T, bool>> expression);

        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression);


        //C=>Add 
        Task<int> AddAsync(T entity);

        Task<int>AddRangeAsync(IEnumerable<T> entities);


        //U=>Update 

        Task<int> UpdateAsync(T entity);

        Task<int> UpdateRangeAsync(IEnumerable<T> entities);

        //D=>Delete,Delete Range Async, DeleteByIdAsync
        Task <int>DeleteAsync(T entity);

        Task<int> DeleteAsync(Guid id);


        Task <int>DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> ids);




    }
}
