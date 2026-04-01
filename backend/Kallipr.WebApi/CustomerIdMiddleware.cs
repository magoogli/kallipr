using Kallipr.Infrastructure;

namespace Kallipr.WebApi
{
    public class CustomerIdHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomerIdHeaderMiddleware> _logger;

        public CustomerIdHeaderMiddleware(RequestDelegate next, 
            ILogger<CustomerIdHeaderMiddleware> logger) { 
            _logger = logger;
            _next = next;
        }

        // Note that I inject the customerIdProvider in the method rather than the constructor as the middleware is a singleton.
        // And my service has to be scoped.
        public async Task InvokeAsync(HttpContext context, ICustomerIdProvider customerIdProvider)
        {
            var customerIdHeader = context.Request.Headers["X-CustomerId"].FirstOrDefault();
            if (string.IsNullOrEmpty(customerIdHeader))
            {
                _logger.LogTrace("X-CustomerId Header not found");
            }
            else
            {
                customerIdProvider.CustomerId = customerIdHeader;
            }
            await _next(context);   
        }
    }
}
