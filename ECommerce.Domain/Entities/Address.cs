using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string AddressLine { get; set; }
        public string LandMark { get; set; }= string.Empty;
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
    }
}
