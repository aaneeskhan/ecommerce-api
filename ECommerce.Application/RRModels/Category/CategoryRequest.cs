using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Application.RRModels.Category
{
    public class CategoryRequest
    {
        [Required(ErrorMessage ="Category is required")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "File is required")]
        public IFormFile File{ get; set; }
    }
}
