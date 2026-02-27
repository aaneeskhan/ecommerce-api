using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }=Guid.CreateVersion7();

        public DateTime CreatedOn {  get; set; }
    }
}
