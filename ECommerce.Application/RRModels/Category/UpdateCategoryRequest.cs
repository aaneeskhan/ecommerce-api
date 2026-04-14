using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.RRModels.Category
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }

        //[Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }
        public string? Description { get; set; }

        //[Required(ErrorMessage = "FilePath is Required")]
        public IFormFile? File { get; set; }
    }
}
