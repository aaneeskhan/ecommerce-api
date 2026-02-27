using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Application.RRModels.Users;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class AuthService(IAuthRepository authRepository) : IAuthService
    {
        public async Task<int> CustomerSignUp(CustomerAddressCompactRequest model)
        {
            Users users = new Users()
            {

                CreatedOn = DateTime.Now,
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = model.Password,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Customer,
                Salt = "123",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        CreatedOn = DateTime.Now,
                        AddressLine = model.AddressLine,
                        LandMark = model.LandMark,
                        Country = model.Country,
                        State = model.State,
                        City = model.City,
                        PostalCode = model.PostalCode,
                        PhoneNo=model.PhoneNo
                    }
                }
            };
            

           
            int returnValue=await authRepository.AddAsync(users);
            return returnValue;
           
        }



        public async Task<int> EmployeeSignUp(EmployeeAddressCompactRequest model)
        {
            Users users = new Users()
            {

                CreatedOn = DateTime.Now,
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = model.Password,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Admin,
                Salt = "456",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        CreatedOn = DateTime.Now,
                        AddressLine = model.AddressLine,
                        LandMark = model.LandMark,
                        Country = model.Country,
                        State = model.State,
                        City = model.City,
                        PostalCode = model.PostalCode,
                        PhoneNo=model.PhoneNo
                    }
                }
            };



            int returnValue = await authRepository.AddAsync(users);
            return returnValue;
        }
    }
}
