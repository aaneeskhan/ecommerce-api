using ECommerce.Application.Abstraction.IAppEncryption;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Encryption
{
    public class AppEncryption: IAppEncryption
    {
        public string GenerateSalt()
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            return salt;
        }

        public string HashPassword(string password, string salt)
        {
             return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
    }
}
