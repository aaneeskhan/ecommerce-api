using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IStorageService storageService) : ICategoryService
    {
        public async Task<Result<CategoryResponse>> CreateCategory(CategoryRequest model)
        {
            if (model.File is  null)
                  return   Result<CategoryResponse>.Failure("Please select file ", StatusCodes.Status404NotFound);

            (string filePath, string fileName) = await storageService.SaveFileAsync(model.File);
            var category = new Category
            {
                Name = model.Name,
                IsActive = true,
                Description = model.Description,
                FilePath = filePath,
                FileName = fileName,
            };
           var returnValue = await categoryRepository.AddAsync(category);
            if(returnValue > 0)
            {
                var response = new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    FilePath = filePath,
                    Description = category.Description
                };
                return Result<CategoryResponse>.Success(response);
            }

            return Result<CategoryResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }
    }
}
