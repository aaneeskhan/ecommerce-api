using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.RRModels.Product;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<Result<ProductResponse>> AddProduct(ProductRequest model)
        {
            var product = new Product()
            {
                Title = model.Title,
                Brand = model.Brand,
                Description = model.Description,
                Units = model.Units,
                CategoryId = model.CategoryId
            };

            var res = await productRepository.AddAsync(product);

            if (res > 0)
            {
                var productResponse = new ProductResponse()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Brand = product.Brand,
                    Units = product.Units,
                    CategoryId = product.CategoryId
                };
                return Result<ProductResponse>.Success(productResponse);
            }
            return Result<ProductResponse>.Failure("Something went Wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<IEnumerable<ProductResponse>>> GetAllProducts()
        {
            var products=await productRepository.GetAllAsync();
            if (products is null)
            {
                return Result<IEnumerable<ProductResponse>>.Failure("No Products found", StatusCodes.Status404NotFound);
            }
            var productResponses = products.Select(x => new ProductResponse()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Brand = x.Brand,
                Units = x.Units,
                CategoryId = x.CategoryId
            });
            return Result<IEnumerable< ProductResponse>>.Success(productResponses);

        }

        public async Task<Result<ProductResponse>> GetProductById(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return Result<ProductResponse>.Failure("No Corresponding Product found", StatusCodes.Status404NotFound);
            }
            var productResponse = new ProductResponse()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Brand = product.Brand,
                Units = product.Units,
                CategoryId = product.CategoryId
            };
            return Result<ProductResponse>.Success(productResponse);
        }
    }
}
