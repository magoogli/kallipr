using Kallipr.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.Devices
{
    public class DeviceService : IDeviceService
    {
        private readonly KalliprDbContext _dbContext;
        public DeviceService(KalliprDbContext kalliprDbContext) { 
            _dbContext = kalliprDbContext;
        }

        async Task<IEnumerable<DeviceDto>> IDeviceService.ListDevicesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Devices
                .AsNoTracking()
                .Select(_ => new DeviceDto(_.CustomerId, _.DeviceId, _.Label, _.Location))
                .ToListAsync(cancellationToken);
        }
    }
}
