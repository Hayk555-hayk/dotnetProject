using System;
using System.Net;
using System.Text.Json;

namespace dotnetProject.Middleware
{

    public class ExeptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionHandlingMiddleware> _logger;

        public ExeptionHandlingMiddleware(RequestDelegate next, ILogger<ExeptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла непредвиденная ошибка: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "На сервере произошла ошибка. Но мы уже её чиним! 🛠"
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

}