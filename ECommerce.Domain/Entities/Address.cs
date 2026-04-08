using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string AddressLine { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string? ContactNo { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
    }
}
