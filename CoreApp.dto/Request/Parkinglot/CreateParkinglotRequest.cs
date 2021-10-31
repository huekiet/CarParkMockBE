using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Parkinglot
{
    public class CreateParkinglotRequest: BaseRequest
    {
        public long ParkArea { get; set; }

        public string ParkName { get; set; }

        public string ParkPlace { get; set; }

        public long ParkPrice { get; set; }

        public string ParkStatus { get; set; }
    }
}
