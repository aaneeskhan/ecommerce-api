using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Address
{
    public class AddressResponse:AddressRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
