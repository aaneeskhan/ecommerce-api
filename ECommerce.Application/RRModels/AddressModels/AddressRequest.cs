using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Application.RRModels.AddressModels
{
    public class AddressRequest
    {
        public string AddressLine { get; set; }
        public string LandMark { get; set; } = string.Empty;
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }




    }

}
