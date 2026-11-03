

using System.Diagnostics;

namespace Ecommerce.API.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;
        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation("Kronometre başladı. Geçen süre : {time}",stopwatch.ElapsedMilliseconds);
            await _next(context);
            _logger.LogInformation("Kronometre durdu. Geçen süre : {time}", stopwatch.ElapsedMilliseconds);
        }

    }
}
