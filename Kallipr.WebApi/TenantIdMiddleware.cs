namespace Kallipr.WebApi
{
    public class TenantIdHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TenantIdHeaderMiddleware> _logger;
        private readonly TenantIdProvider _tenantIdProvider;

        public TenantIdHeaderMiddleware(RequestDelegate next, ILogger<TenantIdHeaderMiddleware> logger, TenantIdProvider tenantIdProvider) { 
            _logger = logger;
            _tenantIdProvider = tenantIdProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            var tenantIdHeader = context.Request.Headers["X-TenantId"].FirstOrDefault();
            if (string.IsNullOrEmpty(tenantIdHeader))
            {
            }
            else
            {
                _tenantIdProvider.TenantId = tenantIdHeader;
            }
            await _next(context);   
        }
    }
}
