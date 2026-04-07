using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.Http;

//using System.Web.Http;
using ECommerce.Application.Utils.Result;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.CustomExtensions
{
    public static class ApiResponseExtension
    {
        public static IResult ApiResponse<T>(this ControllerBase controller, Result<T> result)
        {
            return new CustomResponse<T>
            {
                Value = result,
            };
        }
        
        public class CustomResponse<T>:IResult
        {
           public Result<T> Value {  get; set; }

            public CustomResponse()
            {
                
            }

            public Task ExecuteAsync(HttpContext httpContext)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode=Value.StatusCode;

                var jsonSetting = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {new JsonStringEnumConverter()}
                };
                var json=JsonSerializer.Serialize(Value,jsonSetting);
                return httpContext.Response.WriteAsync(json);
            }
        }
    }
}
