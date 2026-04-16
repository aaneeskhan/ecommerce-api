using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.RRModels.Product;
using ECommerce.Application.Utils.Result;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface IProductService
    {
        Task<Result<ProductResponse>> AddProduct(ProductRequest model);
        Task<Result<IEnumerable<ProductResponse>>> GetAllProducts();
        Task<Result<ProductResponse>> GetProductById(Guid id);


    }
    
}
