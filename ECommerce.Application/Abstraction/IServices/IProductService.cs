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
        // 
        Task<Result<IEnumerable<ProductResponse>>> GetProductsByCategoryId(Guid catId); // Get all Products by Category Id including Product Details the old details
        Task<Result<ProductResponse>> GetProductById(Guid id);// Get all Products by Id

        Task<Result<ProductResponse>> UpdateProduct(Guid id, ProductRequest model);
         Task<Result<string>> DeleteProduct(Guid id); // UNLESS All Product Details are deleted, the product cannot be deleted. 409 Conflict when having details

        // Jeans Levis 50  -40  10  1000
        // Jeans 100    1500




    }
    
}
