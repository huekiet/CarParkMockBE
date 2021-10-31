using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Trip
{
    public class UpdateTripRequest: CreateTripRequest
    {
        public long TripId { get; set; }

    }
}
