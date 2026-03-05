using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.AppEncryption;
using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Application.RRModels.Users;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class AuthService(IAuthRepository authRepository, IAppEncryption appEncryption) : IAuthService
    {

        #region Customer SignUp
        public async Task<int> CustomerSignUp(CustomerAddressCompactRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword = appEncryption.HashPassword(model.Password, salt);

       

            Users users = new Users()
            {

                CreatedOn = DateTime.Now,
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = hashedPassword,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Customer,
                Salt = salt,
                Addresses = model.Addresses.Select(address => new Address
                {
                    CreatedOn = DateTime.Now,
                    AddressLine = address.AddressLine,
                    LandMark = address.LandMark,
                    Country = address.Country,
                    State = address.State,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    PhoneNo = model.PhoneNo
                }).ToList()

            };



            int returnValue = await authRepository.AddAsync(users);
            return returnValue;

        }

        #endregion



        #region Employee SignUp
        public async Task<int> EmployeeSignUp(EmployeeAddressCompactRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword = appEncryption.HashPassword(model.Password, salt);
            List<Address> addressList = new List<Address>();
            foreach (var address in model.Addresses)
            {
                Address addrs = new Address()
                {
                    CreatedOn = DateTime.Now,
                    AddressLine = address.AddressLine,
                    LandMark = address.LandMark,
                    Country = address.Country,
                    State = address.State,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    PhoneNo = model.PhoneNo,

                };
                addressList.Add(addrs);
            }

            Users users = new Users()
            {

                CreatedOn = DateTime.Now,
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = hashedPassword,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Admin,
                Salt = salt,
                Addresses = addressList
            };



            int returnValue = await authRepository.AddAsync(users);
            return returnValue;
        }
        #endregion



        #region Login

        public async Task<int> Login(string userName, string password)
        {
            var user = await authRepository.FirstOrDefaultAsync(usr => usr.Email == userName);
            if (user == null)
            {
                return 0;
            }
            var hashedPassword = appEncryption.HashPassword(password, user.Password);
            if (!hashedPassword.Equals(user.Password))
            {
                return 1;
            }
            return 2;
        }
        #endregion


    }
}
