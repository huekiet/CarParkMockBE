using CoreApp.dto.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Dto
{
    public class TripDto
    {
        public long TripId { get; set; }

        public int BookedTicketNumber { get; set; }

        public string CarType { get; set; }

        public DateTime? DepartureDate { get; set; }

        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan? DepartureTime { get; set; }

        public string Destination { get; set; }

        public string Driver { get; set; }

        public int MaximumOnlineTicketNumber { get; set; }

    }
}
