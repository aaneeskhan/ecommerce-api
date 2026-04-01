using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repository
{
    public class BaseRepository<T>(ECommerceContext context):IBaseRepository<T> where T : BaseEntity, new()
    {
        public async Task<int> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddRAngeAsync(IEnumerable<T> entities)
        {
            await context.AddRangeAsync(entities);
            return await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => context.Set<T>().Count(expression));
        }

        public async Task<int> DeleteAsync(T entity)
        {
            await Task.Run(() => context.Remove(entity));
            return await context.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = new T()
            {
                Id = id
            };
            await Task.Run(() => context.Remove(entity));
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => context.RemoveRange(entities));
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            var models = new List<T>();
            foreach (var id in ids)
            {
                var model = new T()
                {
                    Id = id
                };
                models.Add(model);
            }
            ;
            await Task.Run(() => context.RemoveRange(models));
            return await context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => context.Set<T>().Where(expression));
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => context.Set<T>().FirstOrDefault(expression));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => context.Set<T>().LastOrDefault(expression));
        }

        public async Task<int> UpdateAsync(T entity)
        {
            await Task.Run(() => context.Update(entity));
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => context.UpdateRange(entities));
            return await context.SaveChangesAsync();
        }

    }
}
