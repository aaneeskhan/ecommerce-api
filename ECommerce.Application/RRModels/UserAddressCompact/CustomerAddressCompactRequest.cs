using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.UserAddressCompact
{
    public class CustomerAddressCompactRequest
    {
        public string Email { get; set; }
        public string PhoneNo { get; set; } 
        public string Password { get; set; } 
        public string ConfirmationCode { get; set; }



        public string AddressLine { get; set; }
        public string LandMark { get; set; } = string.Empty;
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

      
    }
}
