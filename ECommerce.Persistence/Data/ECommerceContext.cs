using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ECommerce.Persistence.Data
{
    public class ECommerceContext : DbContext
    {

        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static class ECommerceSeedData
        {
            public static void Seed(ModelBuilder modelBuilder)
            {
                //modelBuilder.Entity<Product>.HasData(

                //    new Product
                //    {
                //        Id = Guid.NewGuid(),
                //        Name = "Product 1",
                //        Description = "Description for Product 1",
                //        Price = 9.99m,
                //        CreatedOn = DateTime.UtcNow
                //    },
                //    );
            }

        }



        public DbSet<Users> Users { get; set; }
    }
}
