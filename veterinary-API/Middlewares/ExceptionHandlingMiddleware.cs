using System.Net;
using System.Text.Json;
using veterinary_API.Exceptions;

namespace veterinary_API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Business exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Business logic error.");
            }
            catch (RepositoryException ex)
            { 
                _logger.LogError(ex, "Repository exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Database access error.");
            }
            catch (Exception ex)
            { 
                _logger.LogCritical(ex, "Unexpected error: {Message}", ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                status = (int)statusCode,
                error = message,
                timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
