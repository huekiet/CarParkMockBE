namespace CoreApp.Model.Entity

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TicketId { get; set; }

        public TimeSpan? BookingTime { get; set; }

        [StringLength(11)]
        public string CustomerName { get; set; }

        [ForeignKey("Car")]
        [StringLength(50)]
        public string LicensePlate { get; set; }

        public long TripId { get; set; }

        public Car Car { get; set; }

        public Trip Trip { get; set; }
    }
}
