using ECommerce.Domain;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Persistence.Data
{
    public static class ECommerceSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid id = Guid.Parse("019d237c-86bf-78c1-aa52-ef2091ce5c25");
            modelBuilder.Entity<Users>().HasData(

                new Users
                {
                    Id = id,
                    Email = "sania@gmail.com",
                    PhoneNo = "9797893466",
                    UserRole = UserRole.Admin,
                    UserStatus = UserStatus.Active,
                    Password = "$2a$11$YOtZkxWhHmwRR4XiiwA1PO8WGZyTnzJXue6ZFesAsJiB8a3bzbXTi",
                    Salt = "$2a$11$YOtZkxWhHmwRR4XiiwA1PO",
                    ConfirmationCode = "",


                }
                );

        

        }

    }

}
