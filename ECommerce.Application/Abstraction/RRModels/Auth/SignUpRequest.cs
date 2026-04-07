using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.RRModels.Auth
{
    public class SignUpRequest
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmationCode { get; set; } = string.Empty;
        public UserRole UserRole { get; set; } 
    }
}
