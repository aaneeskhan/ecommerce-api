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

          
           var products =  await context.Database.SqlQuery<ProductResponse>($@"SELECT P.Id, CategoryId, PD.Id AS ProductDetailId, Title, Brand, [Description], Units, Price, Discount, PD.FileName, PD.FilePath 
                                                            FROM Products P
                                                            INNER JOIN ProductDetails PD
                                                            ON P.Id = PD.ProductId
                                                            where P.CategoryId = {categoryId}").ToListAsync();
            return products;

            //context.Database.SqlQueryRaw<IEnumerable<ProductResponse>>(@"SELECT CategoryId, Title, Brand, [Description], Units, ProductId, Price, Discount, PD.FileName, PD.FilePath 
            //                                                FROM Products P
            //                                                INNER JOIN ProductDetails PD
            //                                                ON P.Id = PD.ProductId
            //                                                where P.CategoryId = @categoryId", categoryId);
        }
    }
}
