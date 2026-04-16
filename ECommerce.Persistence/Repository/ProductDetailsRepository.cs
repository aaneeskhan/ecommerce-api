using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;

namespace ECommerce.Persistence.Repository
{
    public class ProductDetailsRepository(ECommerceContext context) : BaseRepository<ProductDetails>(context), IProductDetailsRepository
    {
    }
}
