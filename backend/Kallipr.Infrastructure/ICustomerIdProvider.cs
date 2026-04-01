using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Infrastructure
{
    public interface ICustomerIdProvider
    {
        public string CustomerId { get; set; }
    }
}
