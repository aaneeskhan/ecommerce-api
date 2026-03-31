using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        // AddAsync(T entity);
        // UpdateAsync(T entity);
        // DeleteAsync(T entity);
        // DeleteByIdAsync(Guid id);

        // GetAllAsync();
        // GetByIdAsync(Guid id);
        // FindAsync(params object[] keyValues);
        // FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        // LastOrDefaultAsync(Expression<Func<T, bool>> predicate);
        // AnyAsync(Expression<Func<T, bool>> predicate);
        // CountAsync(Expression<Func<T, bool>> predicate);

        // AddRangeAsync(IEnumerable<T> entities);
        // DeleteRangeAsync(IEnumerable<T> entities);
        // DeleteRangeByIdsAsync(IEnumerable<Guid> ids);
        // UpdateRangeAsync(IEnumerable<T> entities);
    }
}
