using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> CreateProduct([FromForm] ProductRequest model)
                                         =>   this.ApiResponse(await productService.AddProduct(model));

        [HttpGet("{catId:guid}")]
        public async Task<IResult> GetProductsByCategoryId(Guid catId)
                                       => this.ApiResponse(await productService.GetProductsByCategoryId(catId));


    }
}
