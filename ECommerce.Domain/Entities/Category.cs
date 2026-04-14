using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string FilePath { get; set; }
        public string FileName { get; set; }

        
    }
}
