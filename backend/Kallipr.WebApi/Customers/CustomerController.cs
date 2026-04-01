using Kallipr.Application.TelemetryEvents;
using Kallipr.Application.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace Kallipr.WebApi.TelemetryEvents
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet(Name = "ListCustomers")]
        public async Task<IEnumerable<CustomerDto>> ListCustomersAsync(CancellationToken cancellationToken)
        {
            return await _customerService.ListCustomersAsync(cancellationToken);
        }
    }
}
