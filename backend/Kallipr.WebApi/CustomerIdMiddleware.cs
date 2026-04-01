namespace Kallipr.WebApi
{
    public class CustomerIdHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomerIdHeaderMiddleware> _logger;
        private readonly CustomerIdProvider _customerIdProvider;

        public CustomerIdHeaderMiddleware(RequestDelegate next, ILogger<CustomerIdHeaderMiddleware> logger, CustomerIdProvider customerIdProvider) { 
            _logger = logger;
            _customerIdProvider = customerIdProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            var customerIdHeader = context.Request.Headers["X-CustomerId"].FirstOrDefault();
            if (string.IsNullOrEmpty(customerIdHeader))
            {
                _logger.LogTrace("X-CustomerId Header not found");
            }
            else
            {
                _customerIdProvider.CustomerId = customerIdHeader;
            }
            await _next(context);   
        }
    }
}
