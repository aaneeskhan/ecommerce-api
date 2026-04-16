using ECommerce.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Product
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Units Units { get; set; }
        public Guid CategoryId { get; set; }

        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string   FilePath { get; set; }

        public string FileName { get; set; }

        public Guid ProductDetailId { get; set; }
    }
}
