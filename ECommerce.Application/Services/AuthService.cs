using ECommerce.Application.Abstraction.AppEncryption;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.RRModels.UserAddressCompact;
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
        public async Task<int> CustomerSignUp(UserAddressCompactRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword = appEncryption.HashPassword(model.Password, salt);

       

            Users users = new Users()
            {

                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = hashedPassword,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Customer,
                Salt = salt,
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        AddressLine = model.Address.AddressLine,
                        LandMark = model.Address.LandMark,
                        Country = model.Address.Country,
                        State = model.Address.State,
                        City = model.Address.City,
                        PostalCode = model.Address.PostalCode,
                        PhoneNo=model.Address.PhoneNo
                    }
                }
               

            };



            int returnValue = await authRepository.AddAsync(users);
            return returnValue;

        }

        #endregion



        #region Employee SignUp
        public async Task<int> EmployeeSignUp(UserAddressCompactRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword = appEncryption.HashPassword(model.Password, salt);
          
            Users users = new Users()
            {

                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = hashedPassword,
                ConfirmationCode = model.ConfirmationCode,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Admin,
                Salt = salt,
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        AddressLine = model.Address.AddressLine,
                        LandMark = model.Address.LandMark,
                        Country = model.Address.Country,
                        State = model.Address.State,
                        City = model.Address.City,
                        PostalCode = model.Address.PostalCode,
                        PhoneNo=model.Address.PhoneNo
                    }
                }
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
            var hashedPassword = appEncryption.HashPassword(password, user.Salt);
            if (!hashedPassword.Equals(user.Password))
            {
                return 1;
            }
            return 2;
        }
        #endregion


    }
}
