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
            Guid id = Guid.CreateVersion7();
            modelBuilder.Entity<Users>().HasData(

                new Users
                {
                    Id = id,
                    Email = "admin@gmail.com",
                    PhoneNo = "9797893466",
                    UserRole = UserRole.Admin,
                    UserStatus = UserStatus.Active,
                    Password = "Password",
                    Salt = "abc",
                    Addresses=new List<Address>
                    {
                        new Address
                        {
                            Id = Guid.CreateVersion7(),
                            UserId = id,
                            AddressLine="BulBul Bagh",
                            LandMark="Near Barzulla Bridge",
                            Country="India",
                            City = "Srinagar",
                            State = "Jammu And Kashmir",
                            PostalCode = "190008",
                            PhoneNo="9419440128"
                        }
                     }
                }
                );
        }

    }

}
