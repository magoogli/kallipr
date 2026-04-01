using Kallipr.Application.Devices;
using Kallipr.Application.TelemetryEvents;
using Kallipr.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kallipr.WebApi.TelemetryEvents
{
    [ApiController]
    [Route("[controller]")]
    public class TelemetryEventController : ControllerBase
    {
        private readonly ILogger<TelemetryEventController> _logger;
        private readonly ITelemetryEventService _telemetryEventService;

        public TelemetryEventController(ILogger<TelemetryEventController> logger, ITelemetryEventService telemetryEventService)
        {
            _logger = logger;
            _telemetryEventService = telemetryEventService;
        }

        [HttpPost(Name = "CreateTelemetryEvent")]
        public async Task CreateTelemetryEvent([FromBody] TelemetryEventDto telemetryEvent, CancellationToken cancellationToken)
        {
            await _telemetryEventService.CreateTelemetryEventAsync(telemetryEvent, cancellationToken);
        }

        [HttpGet(Name = "ListTelemetryEventsByDeviceId")]
        public async Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsByDeviceId([FromQuery] ListTelemetryEventsByDeviceIdRequest request, CancellationToken cancellationToken)
        {
            return await _telemetryEventService.ListTelemetryEventsByDeviceIdAsync(request, cancellationToken);
        }

    }
}
