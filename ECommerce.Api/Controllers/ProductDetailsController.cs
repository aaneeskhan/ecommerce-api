using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        // Get Product Details by Product Id

        // Add New  Product Details By Product Id   Restock, Price, Discount, FilePath, FileName
        // Update Product Details By  Id   Restock, Price, Discount, FilePath, FileName
        // Delete product details by Id

        // Product details will be added when product is added, so we can have a separate endpoint to update the details and delete the details if needed. We can also have an endpoint to get the details by product id, which will be used in the products endpoint to get the details along with the product information.
        //  Delete Product Details By Product Id
    }
}
