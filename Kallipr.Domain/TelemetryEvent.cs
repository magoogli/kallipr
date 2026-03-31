using System;
using System.Collections.Generic;
using System.Text;

namespace Kallipr.Domain
{
    public class TelemetryEvent
    {
        public string CustomerId { get; }
        public string DeviceId { get; }
        public string EventId { get; }
        public DateTime RecordedAt { get;  }
        public string Type { get; }
        public double Value { get; }
        public string Unit { get; }

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
