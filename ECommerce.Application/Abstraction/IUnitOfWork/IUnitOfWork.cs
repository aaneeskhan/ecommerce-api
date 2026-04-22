using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommerce.Application.Abstraction.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTransaction();

        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        //void CommitTransaction(IDbTransaction transaction);

        //void RollbackTransaction(IDbTransaction transaction);
    }
}
