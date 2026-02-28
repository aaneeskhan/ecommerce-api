using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.AppEncryption
{
    public interface IAppEncryption
    {
        public string GenerateSalt();

        public string HashPassword(string password, string salt);
    }
}
