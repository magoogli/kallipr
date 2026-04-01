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
        private readonly ITelemetryEventService _telemetryEventService;


        public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService, ITelemetryEventService telemetryEventService)
        {
            _logger = logger;
            _deviceService = deviceService;
            _telemetryEventService = telemetryEventService;
        }


        [HttpGet(Name = "ListDevices")]
        public async Task<IEnumerable<DeviceDto>> ListDevices(CancellationToken cancellationToken)
        {
            return await _deviceService.ListDevicesAsync(cancellationToken);
        }


        [HttpGet("{deviceId}/TelemetryEvents", Name = "ListTelemetryEvents")]
        public async Task<IEnumerable<TelemetryEventDto>> ListTelemetryEvents(string deviceId, CancellationToken cancellationToken)
        {
            return await _telemetryEventService.ListTelemetryEventsByDeviceIdAsync(deviceId, cancellationToken);
        }

        [HttpGet("{deviceId}/TelemetryEventsWindowInsights", Name = "GetTelemetryEventsWindowInsights")]
        public async Task<TelemetryEventsWindowInsightsDto> GetTelemetryEventsWindowInsightsByDeviceId(string deviceId, CancellationToken cancellationToken)
        {
            return await _telemetryEventService.GetTelemetryEventsWindowInsightsAsync(deviceId, cancellationToken);
        }
    }
}
