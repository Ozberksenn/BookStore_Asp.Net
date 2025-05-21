using System.Net;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _iLoggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService iLoggerService)
        {
            _next = next;
            _iLoggerService = iLoggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                string message = "[Request] HTTP" + context.Request.Method + "-" + context.Request.Path;
                _iLoggerService.Write(message);
                await _next(context);
                message = "[Response] HTTP" + context.Request.Method + " - " + context.Request.Path + "responded " + context.Response.StatusCode;
                _iLoggerService.Write(message);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message;
            _iLoggerService.Write(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}