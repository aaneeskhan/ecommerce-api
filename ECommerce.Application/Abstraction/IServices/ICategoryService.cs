using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.Utils.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface ICategoryService
    {
        Task<Result<CategoryResponse>> CreateCategory(CategoryRequest model);
    }
}
