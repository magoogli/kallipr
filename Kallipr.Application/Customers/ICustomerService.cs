using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.Tenants
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerDto>> ListCustomersAsync(CancellationToken cancellationToken = default);
    }
}
