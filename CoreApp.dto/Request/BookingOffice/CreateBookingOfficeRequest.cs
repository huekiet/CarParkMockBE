using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.BookingOffice
{
    public class CreateBookingOfficeRequest
    {
        public DateTime? EndContractDeadline { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePlace { get; set; }
        public long? OfficePrice { get; set; }
        public DateTime? StartContractDeadline { get; set; }

        public long TripId { get; set; }

    }
}
