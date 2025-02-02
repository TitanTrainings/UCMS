using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UCMS.Website.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var user = httpContext.User.Identity?.Name ?? "Anonymous";
            var requestPath = httpContext.Request.Path;
            var method = httpContext.Request.Method;
            var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            var timestamp = DateTimeOffset.UtcNow;

            //Log to file
            var logMessage = $"{timestamp} | User: {user} | IP: {ipAddress} | Method: {method} | Path: {requestPath}";

            //Detect login attempts
            if (requestPath.StartsWithSegments("/Authentication/Login", StringComparison.OrdinalIgnoreCase) && method == "POST")
            {
                logMessage += " | Action: Login Attempt";
            }

            //Detect course enrollment
            if (requestPath.StartsWithSegments("/Courses/Enroll", StringComparison.OrdinalIgnoreCase) && method == "POST")
            {
                logMessage += " | Action: Course Enrollment";
            }

            _logger.LogInformation(logMessage);

            //Write to file
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string logFilePath = Path.Combine(logDirectory, "UserActivityLog.txt");

            //Ensure the logs directory exists
            if (Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            await File.AppendAllTextAsync(logFilePath, logMessage + Environment.NewLine);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
