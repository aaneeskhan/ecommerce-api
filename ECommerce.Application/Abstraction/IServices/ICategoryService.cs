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
        Task<Result<CategoryResponse>> UpdateCategory(UpdateCategoryRequest model);

        Task<Result<IEnumerable<CategoryResponse>>> GetAllCategories();
        Task<Result<IEnumerable<CategoryResponse>>> GetActiveCategories(bool isActice);
        Task<Result<CategoryResponse>> GetCategoryById(Guid id);
        Task<Result<IEnumerable<CategoryResponse>>> FindCategorybyName(string catName);


        //Task<Result<CategoryResponse>> DeleteCategory(string id);
    }
}
