using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain;

namespace ECommerce.Application.RRModels.Auth
{
    public class SignUpRequest
    {
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole UserRole { get; set; }
    }
}
