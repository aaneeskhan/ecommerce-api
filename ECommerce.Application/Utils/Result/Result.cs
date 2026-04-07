using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Utils.Result
{
    public class Result<T>
    {
        public T Value { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        //public ProblemDetails ProblemDetails { get; set; }

        private Result(T value=default,string message="",bool isSuccess=true,int  statusCode=200)
        {
            Value = value;
            Message = message;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }
        private Result(string message="",int  statusCode=200)
        {
            if(statusCode>=600)
            {
                throw new ArgumentException("status code must be less than 600 for a valid HTTP response");
            }
            if(statusCode<100)
            {
                throw new ArgumentException("status code must be greater than 100 for a valid HTTP response");
            }
            Value = default;
            Message = message;
            IsSuccess = statusCode>=400 ? false : true;
            StatusCode = statusCode;
        }

        public static Result<T> Success (T value = default, string message = "", bool isSuccess = true, int statusCode = 200)
        {
            return new Result<T>(value,message,true,statusCode);
        }

        //public static Result<T> Success(string message = "Success", int statusCode = StatusCodes.Status200OK)
        //{
        //    return new Result<T> ( default, message, true, statusCode);
        //}
        
        public static Result<T> Failure (T value = default, string message = "", bool isSuccess = false, int statusCode = 500)
        {
            return new Result<T>(default,message,false,statusCode);
        }
        public static Result<T> Failure ( string message = "", int statusCode = StatusCodes.Status500InternalServerError)
        {
            return new Result<T>(message,statusCode);
        }

    }
}
