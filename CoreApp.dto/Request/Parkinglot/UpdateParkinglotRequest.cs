using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Parkinglot
{
    public class UpdateParkinglotRequest: CreateParkinglotRequest
    {
        public long ParkId { get; set; }

    }
}
