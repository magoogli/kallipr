using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.Devices
{
    public record DeviceDto(string CustomerId, string DeviceId, string Label, string Location);
}
