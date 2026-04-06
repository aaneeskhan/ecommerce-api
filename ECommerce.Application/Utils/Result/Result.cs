using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ECommerce.Application.Utils.Result
{
    public class Result<T>
    {
        public T Value{ get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        // ProblemDetails for error handling

        private Result(T value= default, string message="", bool isSuccess=true, int statusCode=200)
        {
            if (statusCode >= 600)
            {
                throw new ArgumentException("Status code must be less than 600 for a valid HTTP response.");
            }
            else if (statusCode < 100)
            {
                throw new ArgumentException("Status code must be greater than or equal to 100 for a valid HTTP response.");
            }
            Value = value;
            Message = message;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }


       



        public static Result<T> Success(T value=default, string message = "Success", int statusCode = StatusCodes.Status200OK)
        {
            return new Result<T>(value, message, true, statusCode);
        }


        //public static Result<T> Success(T value = default, string message = "Success", int statusCode = StatusCodes.Status200OK)
        //{
        //    return new Result<T>(value, message, true, statusCode);
        //}

        //public static Result<T> Success(string message = "Success", int statusCode = StatusCodes.Status200OK)
        //{
        //    return new Result<T>(default, message, true, statusCode);
        //}


        public static Result<T> Failure(string message="Error", int statusCode = StatusCodes.Status500InternalServerError)
        {
            return new Result<T>(default, message, false, statusCode);
        }
    }
}
