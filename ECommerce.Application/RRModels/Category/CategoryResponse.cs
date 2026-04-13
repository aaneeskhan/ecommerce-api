using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.RRModels.Category
{
    public class CategoryResponse 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }
    }
}
