using Kallipr.Infrastructure;

namespace Kallipr.WebApi
{
    public class CustomerIdProvider : ICustomerIdProvider
    {
        public string CustomerId { get; set; }
    }
}
