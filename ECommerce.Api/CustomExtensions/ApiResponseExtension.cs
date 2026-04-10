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
    }
    public class CustomResponse<T> : IResult
    {
        public Result<T> Value { get; set; }

      

        public Task ExecuteAsync(HttpContext httpContext)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = Value.StatusCode;

            var jsonSetting = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };
            var res = new ResponseModel();
            if (Value.IsSuccess)
            {

                //res.IsSuccess = Value.IsSuccess;
                res.Message = Value.Message;
                res.Data = Value.Value;
            }
            else
            {

                res.Data = null;
                //res.IsSuccess = false;
                res.Message = "";
                res.ProblemDetails = Value.ProblemDetails;
            }
            var json = JsonSerializer.Serialize(Value, jsonSetting);
            return  httpContext.Response.WriteAsync(json);
        }
    }

    public class ResponseModel
    {
        //public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public ProblemDetails ProblemDetails { get; set; }
    }


}
