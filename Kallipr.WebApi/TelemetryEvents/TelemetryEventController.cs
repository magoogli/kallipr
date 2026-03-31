using Kallipr.Application.TelemetryEvents;
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
        public async Task CreateTelemetryEvent()
        {
            await _telemetryEventService.CreateTelemetryEvent();
        }
    }
}
