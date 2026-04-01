using Kallipr.Application.Devices;
using Kallipr.Application.TelemetryEvents;
using Microsoft.AspNetCore.Mvc;

namespace Kallipr.WebApi.TelemetryEvents
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceService _deviceService;

        public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }


        [HttpGet(Name = "ListDevices")]
        public async Task<IEnumerable<DeviceDto>> ListDevices(CancellationToken cancellationToken)
        {
            return await _deviceService.ListDevicesAsync(cancellationToken);
        }
    }
}
