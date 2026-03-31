using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public interface ITelemetryEventService
    {
        public Task CreateTelemetryEventAsync(CancellationToken cancellationToken = default);
        public Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsAsync(CancellationToken cancellationToken = default);
    }
}
