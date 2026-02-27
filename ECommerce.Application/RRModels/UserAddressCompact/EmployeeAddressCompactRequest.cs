using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Users
{
    public class EmployeeAddressCompactRequest
    {

        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmationCode { get; set; }
       


        public string AddressLine { get; set; }
        public string LandMark { get; set; } = string.Empty;
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public UserStatus UserStatus { get; set; } = UserStatus.Active;
        public UserRole UserRole { get; set; } = UserRole.Admin;

    }
}
