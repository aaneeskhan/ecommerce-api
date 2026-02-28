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
    public class BaseRepository<T> (ECommerceContext context): IBaseRepository<T> where T : BaseEntity, new()
    {

        #region Add


            //Add 
            public async Task<int> AddAsync(T entity)
            {

                await context.AddAsync(entity);
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }
            //Add Range
            public async Task<int> AddRangeAsync(IEnumerable<T> entities)
            {
                await context.AddRangeAsync(entities);
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }

        #endregion
      

        #region Delete

            //Delete By Entity
            public async Task <int>DeleteAsync(T entity)
            {
                await Task.Run(() => context.Remove(entity));
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }

            //Delete By Id
            public  async Task<int> DeleteAsync(Guid id)
            {
                await Task.Run(() => context.Remove(id));
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }

            //Delete Range  By Entities
            public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
            {
                await Task.Run(() => context.RemoveRange(entities));
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }


            //Delete Range  By Ids
            public async Task<int> DeleteRangeAsync(IEnumerable<Guid> ids)
            {
                await Task.Run(() => context.RemoveRange(ids));
                var returnValue= await context.SaveChangesAsync();
                return returnValue;
            }

        #endregion


        #region Read

            //Read All
            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await context.Set<T>().ToListAsync();
            }


            //Read By Id
            public async Task<T> GetByIdAsync(Guid id)
            {
                return await context.Set<T>().FindAsync(id);
            }


            //Count
            public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
            {
                 return await context.Set<T>().CountAsync(expression);
            }

            //First Or Default
            public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression);
            }

            //Last Or Default
            public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression)
            {
              return await context.Set<T>().LastOrDefaultAsync(expression);
            }


            //Find By
            public async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> expression)
            {
               throw new NotImplementedException();
            }


            //Where
            public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
            {
                return await Task.Run(() => context.Set<T>().Where(expression).ToList());
            }


            //Exists
            public async Task<bool> ISExistAsync(Expression<Func<T, bool>> expression)
            {
                return await context.Set<T>().AnyAsync(expression);

            }

        #endregion

        
        #region Update

            //Update By Entity
            public async Task<int> UpdateAsync(T entity)
            {
                await Task.Run(() => context.Update(entity));
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }


            //Update  Range By Entities
            public async  Task<int> UpdateRangeAsync(IEnumerable<T> entities)
            {
               await Task.Run(() => context.UpdateRange(entities));
                var returnValue = await context.SaveChangesAsync();
                return returnValue;
            }

        #endregion

    }
}
