using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class ProductDetails:BaseEntity
    {
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string FilePath { get; set; }=string.Empty;
        public string FileName { get; set; }=string.Empty;
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        
    }
}
