using Kallipr.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.Tenants
{
    public class CustomerService : ICustomerService
    {
        private readonly KalliprDbContext _dbContext;
        public CustomerService(KalliprDbContext kalliprDbContext)
        {
            _dbContext = kalliprDbContext;
        }
        public async Task<IEnumerable<CustomerDto>> ListCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .Select(_ => new CustomerDto(_.Id, _.Name))
                .ToListAsync(cancellationToken);
        }
    }
}
