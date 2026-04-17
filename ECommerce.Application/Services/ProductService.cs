using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.RRModels.Product;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class ProductService(IProductRepository productRepository, IProductDetailsRepository productDetailsRepository,
                                IStorageService storageService) : IProductService
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

            var productDetails = new ProductDetails
            {
                Price = model.Price,
                Discount = model.Discount,
                ProductId = product.Id,
            };

           // productDetails.Product = product;
            var res = await productRepository.AddAsync(product);

            if (res > 0)
            {
              (string filePath, string fileName) =  await storageService.SaveFileAsync(model.File);
                productDetails.FilePath= filePath;
                productDetails.FileName= fileName;

            var returnValue = await productDetailsRepository.AddAsync(productDetails);

                if (returnValue > 0)
                {
                    var productResponse = new ProductResponse()
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Description = product.Description,
                        Brand = product.Brand,
                        Units = product.Units,
                        CategoryId = product.CategoryId,
                        Discount = productDetails.Discount,
                        Price= productDetails.Price,
                        ProductDetailId =productDetails.Id,
                        FilePath = filePath,
                        FileName = fileName
                    };
                return Result<ProductResponse>.Success(productResponse);
                }
            }
            return Result<ProductResponse>.Failure("Something went Wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<IEnumerable<ProductResponse>>> GetProductsByCategoryId(Guid catId)
        {

            var products = await productRepository.GetProductsByCategoryId(catId);

            if (products is null)
            {
                return Result<IEnumerable<ProductResponse>>.Failure("No Products found", StatusCodes.Status404NotFound);
            }
            return Result<IEnumerable<ProductResponse>>.Success(products);

          
            //var products=await productRepository.FindByAsync(x=>x.CategoryId == catId);
            //if (products is null)
            //{
            //    return Result<IEnumerable<ProductResponse>>.Failure("No Products found", StatusCodes.Status404NotFound);
            //}
            //List<ProductResponse> list = new List<ProductResponse>();
            //foreach (var product in products)
            //{
            //    ProductResponse productResponse = new ProductResponse();
            //    var productDetails = await productDetailsRepository.FirstOrDefaultAsync(x => x.ProductId == product.Id);
            //    productResponse.Id = product.Id;
            //    productResponse.Title = product.Title;
            //    productResponse.Price = productDetails.Price;
            //    productResponse.CategoryId = product.CategoryId;
            //    productResponse.FilePath = productDetails.FilePath;
            //    productResponse.FileName = productDetails.FileName;
            //    productResponse.Brand = product.Brand;
            //    productResponse.ProductDetailId = productDetails.Id;
            //    productResponse.Description = product.Description;
            //    productResponse.Units = product.Units;
            //    productResponse.Discount = productDetails.Discount;
            //    list.Add(productResponse);
            //}

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
