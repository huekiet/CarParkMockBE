namespace CoreApp.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TripId { get; set; }

        public int BookedTicketNumber { get; set; }

        [StringLength(11)]
        public string CarType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepartureDate { get; set; }

        public TimeSpan? DepartureTime { get; set; }

        [StringLength(50)]
        public string Destination { get; set; }

        [StringLength(11)]
        public string Driver { get; set; }

        public int MaximumOnlineTicketNumber { get; set; }

        public ICollection<BookingOffice> BookingOffices { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
