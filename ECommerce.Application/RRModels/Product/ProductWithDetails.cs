using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Product
{
    public class ProductWithDetails
    {
        public Guid ProductId { get; set; }
        public ProductRequest ProductRequest { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
