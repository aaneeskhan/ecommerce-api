using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.RRModels.Product;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.Persistence.Repository
{
    public class ProductRepository(ECommerceContext context) : BaseRepository<Product>(context), IProductRepository
    {

        public async Task<IEnumerable<ProductResponse>> GetProductsByCategoryId(Guid categoryId)
        {
            //  context.Database.fro
            //context.Database.ExecuteSqlRaw("SELECT * FROM Products WHERE CategoryId = {0}", id); 


            var products = await context.Database.SqlQuery<ProductResponse>($@"SELECT P.Id, CategoryId, PD.Id AS ProductDetailId, Title, Brand, [Description], Units, Price, Discount, PD.FileName, PD.FilePath 
                                                            FROM Products P
                                                            INNER JOIN ProductDetails PD
                                                            ON P.Id = PD.ProductId
                                                            where P.CategoryId = {categoryId}").ToListAsync();


            return products;
        }

        public async Task<IEnumerable<ProductResponseWithJsonResult>> GetProductsByCatId(Guid categoryId)
        {
            var products = await context.Database.SqlQuery<ProductResponseWithJsonResult>($@"SELECT P.Id, P.Title, P.Brand, P.[Description], P.Units, P.CategoryId, P.CreatedOn,
	                                                                       (
		                                                                        SELECT PD.Id AS ProductDetailId, Price, Discount, FilePath, [FileName]  FROM ProductDetails PD
		                                                                        WHERE PD.ProductId = P.Id
		                                                                        FOR JSON PATH --, WITHOUT_ARRAY_WRAPPER
	                                                                        ) AS ProductDetailsJson

                                                                            FROM Products P
                                                                            WHERE P.CategoryId =  {categoryId}").ToListAsync();

            return products;
        }

        public async Task<int> InsertProductWithDetails(ProductWithDetails model)
        {
            string query = $@"INSERT INTO Products VALUES('{model.ProductId}', '{model.ProductRequest.Title}', '{model.ProductRequest.Brand}','{model.ProductRequest.Description}', {(int)model.ProductRequest.Units} , '{model.ProductRequest.CategoryId}', '{model.CreatedOn}')";

            //query += $@" INSERT INTO ProductDetails VALUES('{Guid.CreateVersion7()}', {model.ProductRequest.Price}, {model.ProductRequest.Discount}, '{model.FilePath}', '{model.FileName}', '{model.ProductId}', '{DateTimeOffset.UtcNow}')";

      

           return await context.Database.ExecuteSqlAsync($@"{query}");
        }
    }
}
