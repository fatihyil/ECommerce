namespace Ecommerce.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context) 
        {
            _logger.LogInformation("request received");
            await _next(context);
            _logger.LogInformation("Bilgi : {Method},{Path} -> {Statuscode},Yanıt uzunluğu : {Body}", context.Request.Method, context.Request.Path, context.Response.StatusCode, context.Response.ContentLength);
        }
    }
}
