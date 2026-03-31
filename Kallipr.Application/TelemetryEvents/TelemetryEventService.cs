using Kallipr.Application.Devices;
using Kallipr.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public class TelemetryEventService
    {
        private readonly KalliprDbContext _dbContext;
        public TelemetryEventService(KalliprDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTelemetryEventAsync(CancellationToken cancellationToken = default)
        {
            _dbContext.TelemetryEvents.Add(new Domain.TelemetryEvent
            {
                Id = Guid.NewGuid(),
                DeviceId = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                EventType = "TestEvent",
                Data = "TestData"
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        async Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.TelemetryEvents.Select(_ => new TelemetryEventDto(_.CustomerId, _.DeviceId, _.Label, _.Location))
                .ToListAsync(cancellationToken);
        }
    }
}
