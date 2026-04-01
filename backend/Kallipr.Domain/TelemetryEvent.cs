using System;
using System.Collections.Generic;
using System.Text;

namespace Kallipr.Domain
{
    public class TelemetryEvent
    {
        public long Id { get; private set; }
        public string CustomerId { get; private set; }
        public string DeviceId { get; private set; }
        public string EventId { get; private set; }
        public DateTime RecordedAt { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }
        public string Unit { get; private set; }

        protected TelemetryEvent() { }

        public TelemetryEvent(string customerId, string deviceId, string eventId, DateTime recordedAt, string type, double value, string unit)
        {
            CustomerId = customerId;
            DeviceId = deviceId;
            EventId = eventId;
            RecordedAt = recordedAt;
            Type = type;
            Value = value;
            Unit = unit;
        }
    }
}
