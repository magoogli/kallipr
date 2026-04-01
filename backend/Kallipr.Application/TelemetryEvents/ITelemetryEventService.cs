using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public interface ITelemetryEventService
    {
        public Task CreateTelemetryEventAsync(TelemetryEventDto telemetryEvent, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsByDeviceIdAsync(string deviceId, CancellationToken cancellationToken = default);
        public Task<TelemetryEventsWindowInsightsDto> GetTelemetryEventsWindowInsightsAsync(string deviceId, CancellationToken cancellationToken = default);

    }
}
