using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services;

namespace clientesAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try {
                await _next(httpContext);
            }
            catch(Exception err)
            {
                await HandleExceptionAsync(httpContext, err);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception err)
        {
            int statusCode = getCode(err.InnerException);
            var errorObj = new
            {
                code = statusCode,
                message = err.Message
            };
            httpContext.Response.StatusCode = statusCode;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
        }

        private static int getCode(Exception ex)
        {
            if (ex.GetType() == typeof(ServicesException))
            {
                return ((ServicesException)ex).code;
            }
            return 500;
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
