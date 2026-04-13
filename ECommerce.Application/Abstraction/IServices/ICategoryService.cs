using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.Utils.Result;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface ICategoryService
    {
        Task<Result<CategoryResponse>> CreateCategory(CategoryRequest model);
    }
}
