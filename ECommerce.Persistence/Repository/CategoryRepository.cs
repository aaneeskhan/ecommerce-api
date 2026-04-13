using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Persistence.Repository
{
    public class CategoryRepository(ECommerceContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        
    }
}
