using Kallipr.Application.Devices;
using Kallipr.Domain;
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

        private DateTime? GetLatestTelemetryEventTimestamp(string deviceId)
        {
            return _dbContext
                .TelemetryEvents
                .AsNoTracking()
                .OrderByDescending(_ => _.RecordedAt)
                .Select(_ => _.RecordedAt)
                .FirstOrDefault();
        }

        private IQueryable<TelemetryEvent> GetEventsIn24HourWindowQuery(DateTime latestTimestamp, string deviceId)
        {
            return _dbContext.TelemetryEvents
              .AsNoTracking()
              .OrderByDescending(_ => _.RecordedAt)
              .Where(_ => _.DeviceId == deviceId)
              .Where(_ => _.RecordedAt >= latestTimestamp.AddHours(-24));
        }

        public async Task<TelemetryEventsWindowInsightsDto> GetTelemetryEventsWindowInsightsAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            DateTime? latestTimestamp = GetLatestTelemetryEventTimestamp(deviceId);

            if (latestTimestamp == null)
            {
                return null;
            }

            var valueQuery = GetEventsIn24HourWindowQuery(latestTimestamp.Value, deviceId)
                .Select(_ => _.Value);

            var latest = valueQuery.FirstOrDefault();
            var min = valueQuery.Min();
            var max = valueQuery.Max();
            var average = valueQuery.Average();

            return new TelemetryEventsWindowInsightsDto()
            {
                LatestValue = latest,
                AverageValue = average,
                MaximumValue = max,
                MinimumValue = min
            };

        }


        public async Task<IEnumerable<TelemetryEventDto>> ListTelemetryEventsByDeviceIdAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            DateTime? latestTimestamp = GetLatestTelemetryEventTimestamp(deviceId);

            if (latestTimestamp == null)
            {
                return new List<TelemetryEventDto>();
            }

            return await GetEventsIn24HourWindowQuery(latestTimestamp.Value, deviceId)
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
                .ToListAsync(cancellationToken);
        }

    }
}
