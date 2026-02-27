using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Users:BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
        public string Salt { get; set; }= string.Empty;
        public string ConfirmationCode { get; set; }
        public UserStatus UserStatus { get; set; }=UserStatus.Active;
        public UserRole UserRole { get; set; } = UserRole.Customer;

        public ICollection<Address> Addresses { get; set; }
    }
}
