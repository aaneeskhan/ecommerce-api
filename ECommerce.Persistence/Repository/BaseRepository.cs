using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Persistence.Repository
{
    internal class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly ECommerceContext context;

        public BaseRepository(ECommerceContext context)
        {
            this.context = context;
        }


        #region Read

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExitAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().LastOrDefaultAsync(expression);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().CountAsync(expression);
        }
        public async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => context.Set<T>().Where(expression));
        }

        #endregion


        #region Create
        public async Task<int> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            var returnvalue = await context.SaveChangesAsync();
            return returnvalue;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await context.AddRangeAsync(entities);
            var returnvalue = await context.SaveChangesAsync();
            return returnvalue;
        }
        #endregion


        #region Update
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
        #endregion


        #region Delete
        public async Task<int> DeleteAsync(T entity)
        {
            context.Remove(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => context.RemoveRange(entities));
            var returnvalue = await context.SaveChangesAsync();
            return returnvalue;
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            var entity = new T() { Id = Id };
            await Task.Run(() => context.Remove(entity));
            return await context.SaveChangesAsync();

        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Guid> Ids)
        {
            List<T> entities = new List<T>();
            foreach (var id in Ids)
            {
                var entity = new T() { Id = id };
                entities.Add(entity);


            }
            await Task.Run(() => context.RemoveRange(entities));
            return await context.SaveChangesAsync();
        }
        #endregion
    }
}
