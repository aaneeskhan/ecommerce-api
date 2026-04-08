using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Address
{
    public class AddressRequest
    {
        public string AddressLine { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string? ContactNo { get; set; }

    }
}
