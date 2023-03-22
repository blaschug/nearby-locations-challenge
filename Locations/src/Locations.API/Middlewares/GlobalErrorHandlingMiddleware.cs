using System.Net;
using System.Text.Json;
using FluentValidation;
using Locations.Infrastructure.Exceptions;

namespace nearby_locations_challenge.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(LocationsProviderException))
            {
                message = exception.Message;
                status = HttpStatusCode.ServiceUnavailable;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(ValidationException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadGateway;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
                message = exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
            }

            var exceptionResult = string.IsNullOrEmpty(stackTrace) ? 
                JsonSerializer.Serialize(new { error = message }): JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}

