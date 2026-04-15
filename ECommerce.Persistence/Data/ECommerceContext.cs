using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }


  


        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails{ get; set; }
        public DbSet<AppFiles> AppFiles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }


    }
}
