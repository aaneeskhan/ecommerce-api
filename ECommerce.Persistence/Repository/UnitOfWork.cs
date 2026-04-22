using ECommerce.Application.Abstraction.IUnitOfWork;
using ECommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommerce.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext _context;

        public UnitOfWork(ECommerceContext context)
        {
            _context = context;
        }

        public IDbTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction().GetDbTransaction();
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
