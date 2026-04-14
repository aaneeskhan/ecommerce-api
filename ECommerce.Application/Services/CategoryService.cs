using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository,IStorageService storageService) : ICategoryService
    {
        public async Task<Result<CategoryResponse>> CreateCategory(CategoryRequest model)
        {
            if(model.File is null)
            {
                return Result<CategoryResponse>.Failure("Please insert File",StatusCodes.Status404NotFound);
            }
             (string filePath,string fileName)=await storageService.SaveFileAsync(model.File);
            var category = new Category()
            {
                Name= model.Name,
                Description= model.Description,
                IsActive=true,
                FilePath=filePath,
                FileName=fileName
            };
            var res=await categoryRepository.AddAsync(category);

            if(res>0)
            {
                var categoryResponse= new CategoryResponse()
                {
                    Name=category.Name,
                    Id=category.Id,
                    Description=category.Description,
                    FilePath=category.FilePath,
                    IsActive = category.IsActive,
                };
                return  Result<CategoryResponse>.Success(categoryResponse);
            }
            return Result<CategoryResponse>.Failure("Something went Wrong", StatusCodes.Status500InternalServerError);
        }

        public Task<Result<IEnumerable<CategoryResponse>>> FindCategoryByName(string catName)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CategoryResponse>>> GetActiveCategories(bool isActive)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CategoryResponse>>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Result<CategoryResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CategoryResponse>> UpdateCategory(UpdateCategoryRequest model)
        {
            if(model.File is not null)
            {

            }
            return default;
        }
    }
}
