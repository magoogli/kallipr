using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.Devices
{
    public interface IDeviceService
    {
        public Task<IEnumerable<DeviceDto>> ListDevicesAsync(CancellationToken cancellationToken = default); 
    }
}
