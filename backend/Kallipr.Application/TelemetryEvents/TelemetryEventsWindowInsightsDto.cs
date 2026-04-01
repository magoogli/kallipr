using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Application.TelemetryEvents
{
    public class TelemetryEventsWindowInsightsDto
    {
        public double LatestValue { get; set; }
        public double MinimumValue { get; set; }
        public double MaximumValue { get; set; }
        public double AverageValue { get; set; }

    }
}
