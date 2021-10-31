using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.BookingOffice
{
    public class UpdateBookingOfficeRequest: CreateBookingOfficeRequest
    {
        public long OfficeId { get; set; }

    }
}
