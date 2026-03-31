using Kallipr.Application.Devices;
using Kallipr.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public class TelemetryEventService : ITelemetryEventService
    {
        private readonly KalliprDbContext _dbContext;
        public TelemetryEventService(KalliprDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTelemetryEventAsync(TelemetryEventDto telemetryEvent, CancellationToken cancellationToken = default)
        {
            _dbContext.TelemetryEvents.Add(new Domain.TelemetryEvent(
                telemetryEvent.CustomerId,
                telemetryEvent.DeviceId,
                telemetryEvent.EventId,
                telemetryEvent.RecordedAt,
                telemetryEvent.Type,
                telemetryEvent.Value,
                telemetryEvent.Unit)
            );

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsByDeviceIdAsync(ListTelemetryEventsByDeviceIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _dbContext.TelemetryEvents
                .AsNoTracking()
                .Select(_ => new TelemetryEventDto()
                {
                    CustomerId = _.CustomerId,
                    DeviceId = _.DeviceId,
                    EventId = _.EventId,
                    Id = _.Id,
                    RecordedAt = _.RecordedAt,
                    Type = _.Type,
                    Unit = _.Unit,
                    Value = _.Value
                })
                .Where(_ => _.DeviceId == request.DeviceId) 
                .ToListAsync(cancellationToken);
        }

    }
}
