using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Application.RRModels.ProductDetails
{
    public class ProductDetailsResponse
    {
        public Guid ProductDetailId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
}
