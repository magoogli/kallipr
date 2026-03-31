using System;
using System.Collections.Generic;
using System.Text;

namespace Kallipr.Domain
{
    public class Device
    {
        public int Id { get; }
        public string CustomerId { get; }
        public string DeviceId { get; }
        public string Label { get; set; }
        public string Location { get; set; }

        public Device(string customerId, string deviceId, string label, string location)
        {
            CustomerId = customerId;
            DeviceId = deviceId;
            Label = label;
            Location = location;
        }
    }

}
