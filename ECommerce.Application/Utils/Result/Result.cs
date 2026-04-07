using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ECommerce.Application.Utils.Result
{
    public class Result<T>
    {
        public T? Value{ get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsSuccess => ProblemDetails is null;

        public int StatusCode { get; set; }

        public ProblemDetails ProblemDetails { get; set; }

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
            StatusCode = statusCode;
        }


        private Result(ProblemDetails problemDetails)
        {
            StatusCode= problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            ProblemDetails = problemDetails;
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


        public static Result<T> Failure(string message, string details, string type , string instance ,int statusCode)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Type = type,
                Title = message,
                Detail = details,
                Status = statusCode,
                Instance=instance,

            };
            return new Result<T>(problemDetails);
        }


        public static Result<T> Failure(string message, string details,  string instance= "", int statusCode= StatusCodes.Status500InternalServerError)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Type = "",
                Title = message,
                Detail = details,
                Status = statusCode,
                Instance = instance,

            };
            return new Result<T>(problemDetails);
        }

        public static Result<T> Failure(string message,  int statusCode = StatusCodes.Status500InternalServerError)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Type = "",
                Title = message,
                Detail = "",
                Status = statusCode,
                Instance = "",

            };
            return new Result<T>(problemDetails);
        }


        public static Result<T> Failure(ProblemDetails problemDetails)
        {
            return new Result<T>(problemDetails);
        }
    }
}
