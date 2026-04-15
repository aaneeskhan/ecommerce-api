using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string  Title{ get; set; }= string.Empty;

        public string Brand { get; set; }

        public string Description{ get; set; }=string.Empty;

        public Units Units { get; set; }

        public Guid  CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<ProductDetails> ProductDetails{ get; set; }
    }
}
