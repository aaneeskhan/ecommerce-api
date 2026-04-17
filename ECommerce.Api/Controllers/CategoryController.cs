using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IResult> CreateCategory(CategoryRequest model)
        {
            return this.ApiResponse(await categoryService.CreateCategory(model));
        }
        
        [HttpGet("")]
        public async Task<IResult> GetAllCategories()
        {
            return this.ApiResponse(await categoryService.GetAllCategories());
        }
       
        
        [HttpGet("{isActive:bool}")]
        public async Task<IResult> GetAllCategories(bool isActive)
        {
            return this.ApiResponse(await categoryService.GetActiveCategories(isActive));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IResult> GetCategoryById(Guid id)
        {
            return this.ApiResponse(await categoryService.GetCategoryById(id));
        }

        [HttpGet("{name}")]
        public async Task<IResult> FindCategorybyName(string name)
        {
            return this.ApiResponse(await categoryService.FindCategorybyName(name));
        }

        [HttpPut("")]
        public async Task<IResult> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            return this.ApiResponse(await categoryService.UpdateCategory(updateCategoryRequest));
        }
    }
}
