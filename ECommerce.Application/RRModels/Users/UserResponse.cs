using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Users
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public UserStatus UserStatus { get; set; } = UserStatus.Active;
        public UserRole UserRole { get; set; } = UserRole.Customer;
    }
}
