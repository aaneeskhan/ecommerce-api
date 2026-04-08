using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Address
{
    public class UpdateAddressRequest:AddressRequest
    {
        public Guid Id { get; set; }
    }
}
