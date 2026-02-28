using ECommerce.Application.RRModels.AddressModels;
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

        public List<AddressRequest> Addresses { get; set; }

    }
}
