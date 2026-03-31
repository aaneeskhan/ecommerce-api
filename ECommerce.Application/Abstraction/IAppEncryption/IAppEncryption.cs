using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IAppEncryption
{
    public interface IAppEncryption
    {
        public string GenerateSalt();
        public string HashPassword(string password, string salt);

    }
}
