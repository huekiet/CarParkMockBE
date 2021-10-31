using CoreApp.dto.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Ticket
{
    public class CreateTicketRequest
    {
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan BookingTime { get; set; }

        public string CustomerName { get; set; }

        public string LicensePlate { get; set; }

        public long TripId { get; set; }
    }
}
