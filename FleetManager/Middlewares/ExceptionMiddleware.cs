using System.Net;
using System.Text.Json;

namespace FleetManager.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, "An unhandled exception occurred during request execution.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                ArgumentException => HttpStatusCode.BadRequest,     
                InvalidOperationException => HttpStatusCode.BadRequest, 
                _ => HttpStatusCode.InternalServerError             
            };

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Detail = statusCode == HttpStatusCode.InternalServerError
                         ? "A connection error or internal server issue occurred. Please try again later."
                         : "Validation error."
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
