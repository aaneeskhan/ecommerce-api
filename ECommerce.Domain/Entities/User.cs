using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{

    public class User:BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Salt { get; set; }= string.Empty;
        public string ConfirmationCode { get; set; }=string.Empty;
        public UserStatus UserStatus { get; set; }=UserStatus.Active;
        public UserRole UserRole { get; set; } = UserRole.Customer;

    }
}
