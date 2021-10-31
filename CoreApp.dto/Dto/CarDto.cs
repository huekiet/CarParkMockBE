using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Dto
{
    public class CarDto
    {
        public string LicensePlate { get; set; }

        public string CarColor { get; set; }

        public string CarType { get; set; }

        public string Company { get; set; }

        public long ParkId { get; set; }
        
        public string ParkName { get; set; }

    }
}
