using ECommerce.Application.Abstraction.AppEncryption;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.RRModels.Login;
using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class AuthService(IAuthRepository authRepository, IAppEncryption appEncryption, IJWTProvider jwtProvider) : IAuthService
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
                ConfirmationCode ="",
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Customer,
                Salt = salt,
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
                ConfirmationCode = string.Empty,
                UserStatus = UserStatus.Active,
                UserRole = UserRole.Admin,
                Salt = salt,
                
            };


            int returnValue = await authRepository.AddAsync(users);
            return returnValue;
        }
        #endregion



        #region Login

        public async Task<string> Login(UserLogInRequest model)
        {
            var user = await authRepository.FirstOrDefaultAsync(usr => usr.Email == model.userName);
            if (user is null)
            {
                return "error";
            }
            var hashedPassword = appEncryption.HashPassword(model.password, user.Salt);
            if (!hashedPassword.Equals(user.Password))
            {
                return "error";
            }

             return jwtProvider.GenerateToken(user);
        }
        #endregion


    }
}
