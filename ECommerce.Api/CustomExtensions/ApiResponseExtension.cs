using ECommerce.Api.Controllers.Common;
using ECommerce.Application.Utils.Result;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json; // newsoft.Json for JSON serialization
using System.Text.Json.Serialization;



namespace ECommerce.Api.CustomExtensions
{
    public static class ApiResponseExtension
    {
        public static IResult ApiResponse<T>(this ControllerBase con, Result<T> result)
        {
            return new CustomResponse<T>
            {
                Value = result,
            };
        }

        public class CustomResponse<T> : IResult
        {
            public Result<T> Value{ get; set; }


         
            public Task ExecuteAsync(HttpContext httpContext)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = Value.StatusCode;

                var jsonSetting = new JsonSerializerOptions()
                {
                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                     Converters = { new JsonStringEnumConverter() }
                };

                var obj = new
                {
                    IsSuccess = Value.IsSuccess,
                    Message = Value.Message,
                    Data = Value.Value
                };
                var json = JsonSerializer.Serialize(obj, jsonSetting);
                return httpContext.Response.WriteAsync(json);  


                //if (result.IsSuccess)
                //{
                //    return Results.Json(new
                //    {
                //        success = true,
                //        message = result.Message,
                //        data = result.Value
                //    }, statusCode: result.StatusCode);
                //}
                //else
                //{
                //    return Results.Json(new
                //    {
                //        success = false,
                //        message = result.Message
                //    }, statusCode: result.StatusCode);
                //}
            }
        }
    }
}
