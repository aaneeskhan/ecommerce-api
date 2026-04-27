using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Application.Abstraction.IUnitOfWork;
using ECommerce.Application.RRModels.Category;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository,IStorageService storageService ,IUnitOfWork unitOfWork) : ICategoryService
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
            await categoryRepository.AddAsync(category);
            var res= await unitOfWork.SaveChangeAsync();

            if (res>0)
            {
                var categoryResponse= new CategoryResponse()
                {
                    Name=category.Name,
                    Id=category.Id,
                    Description=category.Description,
                    FilePath=category.FilePath,
                    isActive=category.IsActive,
                };
                return  Result<CategoryResponse>.Success(categoryResponse);
            }
            return Result<CategoryResponse>.Failure("Something went Wrong", StatusCodes.Status500InternalServerError);
        }


        public async Task<Result<IEnumerable<CategoryResponse>>> GetAllCategories()
        {
           
           
            var categories=await categoryRepository.GetAllAsync();
            if(categories is null)
            {
                return Result<IEnumerable<CategoryResponse>>.Failure("Something went Wrong or no categories found", StatusCodes.Status404NotFound);
            }
            var categoryResponses=new List<CategoryResponse>();
            foreach (var category in categories) 
            {
                var categoryResponse = new CategoryResponse()
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description,
                    FilePath = category.FilePath,
                    isActive = category.IsActive
                };
                categoryResponses.Add(categoryResponse);
            }
            return Result<IEnumerable<CategoryResponse>>.Success(categoryResponses);
        }


        public async Task<Result<CategoryResponse>> GetCategoryById(Guid id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return Result<CategoryResponse>.Failure("Something went Wrong or no corresponding category found", StatusCodes.Status404NotFound);
            }

            var categoryResponse = new CategoryResponse()
            {
                Name = category.Name,
                Id = category.Id,
                Description = category.Description,
                FilePath = category.FilePath,
                isActive = category.IsActive
            };
                
            return Result<CategoryResponse>.Success(categoryResponse);
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> FindCategorybyName(string catName)
        {
            var categories = await categoryRepository.FindByAsync(x => x.Name.StartsWith(catName));
            if (categories is null)
            {
                return Result<IEnumerable<CategoryResponse>>.Failure("Something went Wrong or no corresponding categories found", StatusCodes.Status404NotFound);
            }
            var categoryResponses = new List<CategoryResponse>();
            foreach (var category in categories)
            {
                var categoryResponse = new CategoryResponse()
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description,
                    FilePath = category.FilePath,
                    isActive = category.IsActive
                };
                categoryResponses.Add(categoryResponse);
            }
            return Result<IEnumerable<CategoryResponse>>.Success(categoryResponses);
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> GetActiveCategories(bool isActice)
        {
            var categories=await categoryRepository.FindByAsync(x=>x.IsActive==isActice);
            if (categories is null)
            {
                return Result<IEnumerable<CategoryResponse>>.Failure("Something went Wrong or no corresponding categories found", StatusCodes.Status404NotFound);
            }
            var categoryResponses = new List<CategoryResponse>();
            foreach (var category in categories)
            {
                var categoryResponse = new CategoryResponse()
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description,
                    FilePath = category.FilePath,
                    isActive = category.IsActive
                };
                categoryResponses.Add(categoryResponse);
            }
            return Result<IEnumerable<CategoryResponse>>.Success(categoryResponses);
        }



        public async Task<Result<CategoryResponse>> UpdateCategory(UpdateCategoryRequest model)
        {

            var category = await categoryRepository.GetByIdAsync(model.Id);
            if (category is null)
            {
                return Result<CategoryResponse>.Failure("Something went Wrong or no corresponding category found", StatusCodes.Status404NotFound);
            }
            string filePath=category.FilePath;
            string fileName=category.FileName;
            if(model.File is not null)
            {
                (filePath,fileName)=await storageService.UpdateFileAsync(model.File, fileName);
            }

            category.Name = model.Name;
            category.Description= model.Description;
            category.FilePath= filePath;
            category.FileName = fileName;

            await categoryRepository.UpdateAsync(category);
                var res = await unitOfWork.SaveChangeAsync();
            if (res > 0)
            {
                var categoryResponse = new CategoryResponse()
                {
                    Name = category.Name,
                    Id = category.Id,
                    Description = category.Description,
                    FilePath = category.FilePath,
                    isActive = category.IsActive,
                };
                return Result<CategoryResponse>.Success(categoryResponse);
            }
            return Result<CategoryResponse>.Failure("Something went Wrong", StatusCodes.Status500InternalServerError);
        }
    }
}
