using ECommerce.Application.RRModels.AddressModels;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.UserAddressCompact
{
    public class UserAddressCompactRequest
    {
        public string Email { get; set; }
        public string PhoneNo { get; set; } 
        public string Password { get; set; } 
        public string ConfirmationCode { get; set; }

        public AddressRequest Address { get; set; }

     

      
    }
}
