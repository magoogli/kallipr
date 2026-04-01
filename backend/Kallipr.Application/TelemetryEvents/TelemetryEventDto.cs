using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public class TelemetryEventDto
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        public string DeviceId { get; set; }
        public string EventId { get; set; }
        public DateTime RecordedAt { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }

    }


}
