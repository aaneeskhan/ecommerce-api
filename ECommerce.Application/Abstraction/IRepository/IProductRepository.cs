using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Product;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.IRepository
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<IEnumerable<ProductResponse>> GetProductsByCategoryId(Guid id);
    }
}
